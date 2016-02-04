using NUnit.Framework;
using Mercury;

namespace SuperTuples.Test
{
    public sealed class TravisTest : SpecificationByMethod
    {
        protected override void Cases()
        {
            Spec("Travis mercury test case 1"
                .ArrangeNull()
                .Act(_ => _)
                .Assert(_ => Assert.Fail("Failure from mercury test"))
                );
        }
    }
}
