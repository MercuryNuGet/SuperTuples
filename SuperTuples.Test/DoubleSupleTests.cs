using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class DoubleSupleTests : SpecificationByMethod
    {
        protected override void Cases()
        {
            Spec("Double Suple"
                .Arrange()
                .With(typeof(Suple<string, string>))
                .With(typeof(Suple<int, int>))
                .With(typeof(Suple<int, string>))
                .AssertStandardSupleTypeRestrictions()
                );

            Spec("new Suple<int, int>(#value1, #value2)"
                .Arrange()
                .With(new { value1 = 1, value2 = 2 })
                .With(new { value1 = 4, value2 = 5 })
                .Act((data) => new IntSuple(data.value1, data.value2))
                .Assert("value of Value1 #value1 can be read back", (suple, data) => Assert.AreEqual(data.value1, suple.Value1))
                .Assert("value of Value2 #value1 can be read back", (suple, data) => Assert.AreEqual(data.value2, suple.Value2))
                .Assert("to string", (suple, data) => Assert.AreEqual("(" + data.value1 + ", " + data.value2 + ")", suple.ToString()))
               );

            Spec("new Suple<string, string>()"
                .Arrange()
                .With(new { value1 = "abc", value2 = "def", expected = "(abc, def)" })
                .With(new { value1 = "def", value2 = "ghi", expected = "(def, ghi)" })
                .With(new { value1 = (string)null, value2 = "ghi", expected = "(null, ghi)" })
                .With(new { value1 = "def", value2 = (string)null, expected = "(def, null)" })
                .Act((data) => new StringSuple(data.value1, data.value2))
                .Assert("value of can be read back", (suple, data) => Assert.AreEqual(data.value1, suple.Value1))
                .Assert("value of can be read back", (suple, data) => Assert.AreEqual(data.value2, suple.Value2))
                .Assert("to string", (suple, data) => Assert.AreEqual(data.expected, suple.ToString()))
               );

            Spec("new Suple<string, int>()"
                .Arrange()
                .With(new { value1 = "abc", value2 = 5, expected = "(abc, 5)" })
                .With(new { value1 = "def", value2 = 6, expected = "(def, 6)" })
                .With(new { value1 = (string)null, value2 = 8, expected = "(null, 8)" })
                .Act((data) => new StringIntSuple(data.value1, data.value2))
                .Assert("value of can be read back", (suple, data) => Assert.AreEqual(data.value1, suple.Value1))
                .Assert("value of can be read back", (suple, data) => Assert.AreEqual(data.value2, suple.Value2))
                .Assert("to string", (suple, data) => Assert.AreEqual(data.expected, suple.ToString()))
               );

            Spec("Non equality:"
                .Arrange()
                .With(new { value1 = new IntSuple(1, 3), value2 = new IntSuple(2, 3) })
                .With(new { value1 = new IntSuple(3, 4), value2 = new IntSuple(1, 4) })
                .With(new { value1 = new IntSuple(3, 4), value2 = new IntSuple(3, 5) })
                .Act((data) => data)
                .Assert("!#value1.Equals(#value2)", (equalsResult, data) => Assert.AreNotEqual(data.value1, data.value2))
                .Assert("!#value1.Equals(#value2) reflex", (equalsResult, data) => Assert.AreNotEqual(data.value2, data.value1))
                .Assert("of hashcodes !#value1.GetHashCode() != #value2.GetHashCode()", (equalsResult, data) => Assert.AreNotEqual(data.value1.GetHashCode(), data.value2.GetHashCode()))
               );

            Spec("Equality new Suple<int, int>(#value)"
               .Arrange()
               .With(new { value1 = 1, value2 = 2 })
               .With(new { value1 = 2, value2 = 3 })
               .Act((data) => new IntSuple(data.value1, data.value2).Equals(new IntSuple(data.value1, data.value2)))
               .Assert((equalsResult, data) => Assert.IsTrue(equalsResult))
              );

            Spec("Equality of hashcode new Suple<int, int>(#value)"
               .Arrange()
               .With(new { value1 = 1, value2 = 2 })
               .With(new { value1 = 2, value2 = 3 })
               .Act((data) => new { hashCode1 = new IntSuple(data.value1, data.value2).GetHashCode(), hashCode2 = new IntSuple(data.value1, data.value2).GetHashCode() })
               .Assert((hashcodes, data) => Assert.AreEqual(hashcodes.hashCode1, hashcodes.hashCode2))
              );

            Spec("Non Equality new Suple<int>(#value)"
               .Arrange()
               .With(new { value = new IntSuple(1, 2) })
               .With(new { value = new IntSuple(2, 3) })
               .Act((data) => data.value)
               .Assert("to null", (suple, data) => Assert.AreNotEqual(suple, null))
               .Assert("from null", (suple, data) => Assert.AreNotEqual(null, suple))
               .Assert("to object", (suple, data) => Assert.AreNotEqual(suple, new object()))
               .Assert("from object", (suple, data) => Assert.AreNotEqual(new object(), suple))
               .Assert("to descendant type", (suple, data) => Assert.AreNotEqual(suple, new AlienIntSuple(data.value.Value1, data.value.Value2)))
               .Assert("from descendant type", (suple, data) => Assert.AreNotEqual(new AlienIntSuple(data.value.Value1, data.value.Value2), suple))
              );

            Spec("Non equality string:"
                .Arrange()
                .With(new { value1 = new StringSuple("Abc", "b"), value2 = new StringSuple("Def", "b") })
                .With(new { value1 = new StringSuple("Ghi", "c"), value2 = new StringSuple("Jkl", "c") })
                .With(new { value1 = new StringSuple("Ghi", "d"), value2 = new StringSuple(null, "d") })
                .With(new { value1 = new StringSuple("Abc", "b"), value2 = new StringSuple("Abc", "c") })
                .With(new { value1 = new StringSuple("Abc", "b"), value2 = new StringSuple("Abc", null) })
                .Act((data) => data)
                .Assert("!#value1.Equals(#value2)", (equalsResult, data) => Assert.AreNotEqual(data.value1, data.value2))
                .Assert("!#value1.Equals(#value2) reflex", (equalsResult, data) => Assert.AreNotEqual(data.value2, data.value1))
                .Assert("of hashcodes !#value1.GetHashCode() != #value2.GetHashCode()", (equalsResult, data) => Assert.AreNotEqual(data.value1.GetHashCode(), data.value2.GetHashCode()))
               );
        }

        public class IntSuple : Suple<int, int>
        {
            public IntSuple(int value1, int value2)
                : base(value1, value2)
            {
            }
            public int Value1 { get { return Item1; } }
            public int Value2 { get { return Item2; } }
        }

        public class AlienIntSuple : IntSuple
        {
            public AlienIntSuple(int value1, int value2)
                : base(value1, value2)
            {
            }
        }

        public class StringSuple : Suple<string, string>
        {
            public StringSuple(string value1, string value2)
                : base(value1, value2)
            {
            }
            public string Value1 { get { return Item1; } }
            public string Value2 { get { return Item2; } }
        }

        public class StringIntSuple : Suple<string, int>
        {
            public StringIntSuple(string value1, int value2)
                : base(value1, value2)
            {
            }
            public string Value1 { get { return Item1; } }
            public int Value2 { get { return Item2; } }
        }
    }
}
