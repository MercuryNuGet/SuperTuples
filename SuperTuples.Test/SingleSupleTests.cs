using System.Reflection;
using System.Linq;
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
                .Assert("has no public members", sut => CollectionAssert.IsEmpty(sut.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)))
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
        }

        public class IntSuple : Suple<int>
        {
            public IntSuple(int value)
                : base(value)
            {
            }
            public int Value { get { return Item1; } }
        }
    }
}