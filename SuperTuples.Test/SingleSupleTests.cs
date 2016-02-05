using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class SingleSupleTests : SpecificationByMethod
    {
        protected override void Cases()
        {
            Spec("Single Suple"
                .Arrange()
                .With(typeof(Suple<string>))
                .With(typeof(Suple<int>))
                .AssertStandardSupleTypeRestrictions()
                );

            Spec("new Suple<int>(#value)"
                .Arrange()
                .With(new { value = 1 })
                .With(new { value = 2 })
                .Act((data) => new IntSuple(data.value))
                .Assert("value of #value can be read back", (suple, data) => Assert.AreEqual(data.value, suple.Value))
                .Assert("to string", (suple, data) => Assert.AreEqual("(" + data.value + ")", suple.ToString()))
               );

            Spec("new Suple<string>()"
                .Arrange()
                .With(new { value = "abc" })
                .With(new { value = "def" })
                .With(new { value = (string)null })
                .Act((data) => new StringSuple(data.value))
                .Assert("value of can be read back", (suple, data) => Assert.AreEqual(data.value, suple.Value))
                .Assert("to string", (suple, data) => Assert.AreEqual("(" + (data.value ?? "null") + ")", suple.ToString()))
               );

            Spec("Non equality:"
                .Arrange()
                .With(new { value1 = new IntSuple(1), value2 = new IntSuple(2) })
                .With(new { value1 = new IntSuple(3), value2 = new IntSuple(1) })
                .Act((data) => data)
                .Assert("!#value1.Equals(#value2)", (equalsResult, data) => Assert.AreNotEqual(data.value1, data.value2))
                .Assert("!#value1.Equals(#value2) reflex", (equalsResult, data) => Assert.AreNotEqual(data.value2, data.value1))
                .Assert("of hashcodes !#value1.GetHashCode() != #value2.GetHashCode()", (equalsResult, data) => Assert.AreNotEqual(data.value1.GetHashCode(), data.value2.GetHashCode()))
               );

            Spec("Equality new Suple<int>(#value)"
               .Arrange()
               .With(new { value = 1 })
               .With(new { value = 2 })
               .Act((data) => new IntSuple(data.value).Equals(new IntSuple(data.value)))
               .Assert((equalsResult, data) => Assert.IsTrue(equalsResult))
              );

            Spec("Equality of hashcode new Suple<int>(#value)"
               .Arrange()
               .With(new { value = 1 })
               .With(new { value = 2 })
               .Act((data) => new { hashCode1 = new IntSuple(data.value).GetHashCode(), hashCode2 = new IntSuple(data.value).GetHashCode() })
               .Assert((hashcodes, data) => Assert.AreEqual(hashcodes.hashCode1, hashcodes.hashCode2))
              );

            Spec("Non Equality new Suple<int>(#value)"
               .Arrange()
               .With(new { value = new IntSuple(1) })
               .With(new { value = new IntSuple(2) })
               .Act((data) => data.value)
               .Assert("to null", (suple, data) => Assert.AreNotEqual(suple, null))
               .Assert("from null", (suple, data) => Assert.AreNotEqual(null, suple))
               .Assert("to object", (suple, data) => Assert.AreNotEqual(suple, new object()))
               .Assert("from object", (suple, data) => Assert.AreNotEqual(new object(), suple))
               .Assert("to descendant type", (suple, data) => Assert.AreNotEqual(suple, new AlienIntSuple(data.value.Value)))
               .Assert("from descendant type", (suple, data) => Assert.AreNotEqual(new AlienIntSuple(data.value.Value), suple))
              );

            Spec("Non equality string:"
                .Arrange()
                .With(new { value1 = new StringSuple("Abc"), value2 = new StringSuple("Def") })
                .With(new { value1 = new StringSuple("Ghi"), value2 = new StringSuple("Jkl") })
                .With(new { value1 = new StringSuple("Ghi"), value2 = new StringSuple(null) })
                .With(new { value1 = new StringSuple(null), value2 = new StringSuple("Jlk") })
                .Act((data) => data)
                .Assert("!#value1.Equals(#value2)", (equalsResult, data) => Assert.AreNotEqual(data.value1, data.value2))
                .Assert("!#value1.Equals(#value2) reflex", (equalsResult, data) => Assert.AreNotEqual(data.value2, data.value1))
                .Assert("of hashcodes !#value1.GetHashCode() != #value2.GetHashCode()", (equalsResult, data) => Assert.AreNotEqual(data.value1.GetHashCode(), data.value2.GetHashCode()))
               );
        }

        public class IntSuple : Suple<int>
        {
            public IntSuple(int value)
                : base(value)
            {
            }
            public int Value { get { return Item1; } }
        }

        public class AlienIntSuple : IntSuple
        {
            public AlienIntSuple(int value)
                : base(value)
            {
            }
        }

        public class StringSuple : Suple<string>
        {
            public StringSuple(string value)
                : base(value)
            {
            }
            public string Value { get { return Item1; } }
        }
    }
}
