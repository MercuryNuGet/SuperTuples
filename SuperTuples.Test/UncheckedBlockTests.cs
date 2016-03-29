using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class UncheckedBlockTests : MercurySuite
    {
        protected override void Specifications()
        {
            const int expectedHash = 1062386622;

            Specs += "When calculating hash, uses an unchecked environment"
                .Arrange(() => new TrippleString("a", "b", "c"))
                .Act(sut => sut.GetHashCode())
                .Assert(r => Assert.AreEqual(expectedHash, r));

            Specs += "When pre-calculating hash, uses an unchecked environment"
                .Arrange(() => new TrippleStringCached("a", "b", "c"))
                .Act(sut => sut.GetHashCode())
                .Assert(r => Assert.AreEqual(expectedHash, r));
        }

        public class TrippleString : Suple<string, string, string>
        {
            public TrippleString(string a, string b, string c) : base(a, b, c)
            {
            }
        }

        public class TrippleStringCached : Suple<string, string, string>
        {
            public TrippleStringCached(string a, string b, string c) : base(a, b, c, SupleHash.Cached)
            {
            }
        }
    }
}
