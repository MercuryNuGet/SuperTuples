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
                .Arrange(() => typeof(Suple))
                .ActOn(sut => { })
                .Assert("is abstract", sut => Assert.IsTrue(sut.IsAbstract))
                .Assert("is public", sut => Assert.IsTrue(sut.IsPublic))
                .Assert("has no public members", sut => CollectionAssert.IsEmpty(sut.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)))
                );
        }
    }
}
