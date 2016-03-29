using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class UncheckedBlockTests : MercurySuite
    {
        protected override void Specifications()
        {
            const int expectedHash = -32;

            Specs += "When calculating hash, uses an unchecked environment"
                .Arrange(() => new HashOverflow())
                .Act(sut => sut.GetHashCode())
                .Assert(r => Assert.AreEqual(expectedHash, r));

            Specs += "When pre-calculating hash, uses an unchecked environment"
                .Arrange(() => new HashOverflowCached())
                .Act(sut => sut.GetHashCode())
                .Assert(r => Assert.AreEqual(expectedHash, r));
        }

        public class MaxIntHash
        {
            public override int GetHashCode()
            {
                return int.MaxValue;
            }
        }

        public class HashOverflow : Suple<MaxIntHash, MaxIntHash>
        {
            public HashOverflow() : base(new MaxIntHash(), new MaxIntHash())
            {
            }
        }

        public class HashOverflowCached : Suple<MaxIntHash, MaxIntHash>
        {
            public HashOverflowCached() : base(new MaxIntHash(), new MaxIntHash(), SupleHash.Cached)
            {
            }
        }
    }
}
