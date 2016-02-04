using System.Linq;
using System.Reflection;
using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class SingleSupleTests : SpecificationByMethod
    {
        protected override void Cases()
        {
            Spec("Single Suple"
                .Arrange(() => typeof(Suple<string>))
                .ActOn(sut => { })
                .Assert("is abstract", sut => Assert.IsTrue(sut.IsAbstract))
                .Assert("is public", sut => Assert.IsTrue(sut.IsPublic))
                .Assert("has no public members", sut => CollectionAssert.AreEquivalent(new[] { "Equals" }, sut.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Select(m => m.Name)))
                .Assert("has no public fields", sut => CollectionAssert.IsEmpty(sut.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)))
                .Assert("has no writable fields", sut => CollectionAssert.IsEmpty(sut.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(f => !f.IsInitOnly)))
                );

            Spec("new Suple<int>(#value)"
                .ArrangeNull()
                .With(new { value = 1 })
                .With(new { value = 2 })
                .Act((_, data) => new IntSuple(data.value))
                .Assert("value of #value can be read back", (suple, data) => Assert.AreEqual(data.value, suple.Value))
               );

            Spec("new Suple<string>(\"#value\")"
                .ArrangeNull()
                .With(new { value = "abc" })
                .With(new { value = "def" })
                .Act((_, data) => new StringSuple(data.value))
                .Assert("value of \"#value\" can be read back", (suple, data) => Assert.AreEqual(data.value, suple.Value))
               );

            Spec("Non equality:"
                .ArrangeNull()
                .With(new { value1 = 1, value2 = 2 })
                .With(new { value1 = 3, value2 = 1 })
                .Act((_, data) => new IntSuple(data.value1).Equals(new IntSuple(data.value2)))
                .Assert("!new Suple<int>(#value1).Equals(new Suple<int>(#value2))", (equalsResult, data) => Assert.IsFalse(equalsResult))
               );

            Spec("Equality new Suple<int>(#value)"
               .ArrangeNull()
               .With(new { value = 1 })
               .With(new { value = 2 })
               .Act((_, data) => new IntSuple(data.value).Equals(new IntSuple(data.value)))
               .Assert((equalsResult, data) => Assert.IsTrue(equalsResult))
              );

            Spec("Non Equality new Suple<int>(#value)"
               .ArrangeNull()
               .With(new { value = new IntSuple(1) })
               .With(new { value = new IntSuple(2) })
               .Act((_, data) => data.value)
               .Assert("to null", (suple, data) => Assert.AreNotEqual(suple, null))
               .Assert("from null", (suple, data) => Assert.AreNotEqual(null, suple))
               .Assert("to object", (suple, data) => Assert.AreNotEqual(suple, new object()))
               .Assert("from object", (suple, data) => Assert.AreNotEqual(new object(), suple))
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