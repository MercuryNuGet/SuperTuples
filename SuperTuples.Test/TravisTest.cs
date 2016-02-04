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
                .With(new { x = 1, y = 1, expected = 2 })
                .With(new { x = 3, y = 4, expected = 7 })
                .Act((_, data) => data.x + data.y)
                .Assert((actual, data) => Assert.AreEqual(data.expected, actual))
                );
        }
    }
}
