using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class HashCacheTests : MercurySuite
    {
        protected override void Specifications()
        {
            Specs += "When not caching the hash"
                .Arrange()
                .With(new Mutable(1))
                .With(new Mutable(2))
                .Act(m =>
                {
                    var ms = new MutableSuple(m);
                    int hash1 = ms.GetHashCode();
                    m.Value *= 2;
                    int hash2 = ms.GetHashCode();
                    return new { hash1, hash2 };
                })
                .Assert(", hash can change", (hashes, m) => Assert.AreNotEqual(hashes.hash1, hashes.hash2));

            Specs += "When caching the hash"
                .Arrange()
                .With(new Mutable(1))
                .With(new Mutable(2))
                .Act(m =>
                {
                    var ms = new MutableSupleCachedHash(m);
                    int hash1 = ms.GetHashCode();
                    m.Value *= 2;
                    int hash2 = ms.GetHashCode();
                    return new { hash1, hash2 };
                })
                .Assert(", hash cannot change", (hashes, m) => Assert.AreEqual(hashes.hash1, hashes.hash2));
        }

        public class Mutable
        {
            public Mutable(int value)
            {
                Value = value;
            }

            public int Value { get; set; }

            public override int GetHashCode()
            {
                return Value;
            }
        }

        public class MutableSuple : Suple<Mutable>
        {
            public MutableSuple(Mutable value)
                : base(value)
            {
            }
            public Mutable Value { get { return Item1; } }
        }

        public class MutableSupleCachedHash : Suple<Mutable>
        {
            public MutableSupleCachedHash(Mutable value)
                : base(value, SupleHash.Cached)
            {
            }
            public Mutable Value { get { return Item1; } }
        }
    }
}
