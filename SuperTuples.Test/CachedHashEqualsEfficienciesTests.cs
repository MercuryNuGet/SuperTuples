using Mercury;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class CachedHashEqualsEfficienciesTests : MercurySuite
    {
        protected override void Specifications()
        {
            Specs += "When comparing a cached suple with same hash"
                .Arrange()
                .With(new { a = new CachedSuple(new EqualsCounter(123), SupleHash.Cached), b = new CachedSuple(new EqualsCounter(123), SupleHash.Cached) })
                .Act(data => Equals(data.a, data.b))
                .Assert("equals was called on the inner of a", (e, data) =>
                {
                    Assert.AreEqual(1, data.a.Value.EqualsCount);
                    Assert.IsTrue(e);
                });

            Specs += "When comparing a cached suple with different hash"
             .Arrange()
             .With(new { a = new CachedSuple(new EqualsCounter(123), SupleHash.Cached), b = new CachedSuple(new EqualsCounter(456), SupleHash.Cached) })
             .Act(data => Equals(data.a, data.b))
             .Assert("equals was not called on the inner of a", (e, data) =>
             {
                 Assert.AreEqual(0, data.a.Value.EqualsCount);
                 Assert.IsFalse(e);
             });

            Specs += "When comparing a cached suple with a non-cached suple of same type"
             .Arrange()
             .With(new { a = new CachedSuple(new EqualsCounter(123), SupleHash.Cached), b = new CachedSuple(new EqualsCounter(123)) })
             .With(new { a = new CachedSuple(new EqualsCounter(123)), b = new CachedSuple(new EqualsCounter(123), SupleHash.Cached) })
             .Act(data => Equals(data.a, data.b))
             .Assert("equals was called on the inner of a", (e, data) =>
             {
                 Assert.AreEqual(1, data.a.Value.EqualsCount);
                 Assert.IsTrue(e);
             });

            Specs += "When comparing a cached suple with a non-cached suple of same type"
           .Arrange()
           .With(new { a = new CachedSuple(new EqualsCounter(123), SupleHash.Cached), b = new CachedSuple(new EqualsCounter(456)) })
           .With(new { a = new CachedSuple(new EqualsCounter(123)), b = new CachedSuple(new EqualsCounter(456), SupleHash.Cached) })
           .Act(data => Equals(data.a, data.b))
           .Assert("equals was called on the inner of a", (e, data) =>
           {
               Assert.AreEqual(1, data.a.Value.EqualsCount);
               Assert.IsFalse(e);
           });
        }

        public class EqualsCounter
        {
            private int _value;

            public EqualsCounter(int value)
            {
                _value = value;
            }

            public int EqualsCount { get; private set; }

            public override bool Equals(object obj)
            {
                EqualsCount++;
                var inner = obj as EqualsCounter;
                return obj != null && inner._value == _value;
            }

            public override int GetHashCode()
            {
                return _value;
            }
        }

        public class CachedSuple : Suple<EqualsCounter>
        {
            public CachedSuple(EqualsCounter value, SupleHash hashMode) : base(value, hashMode)
            {
            }
            public CachedSuple(EqualsCounter value) : base(value)
            {
            }
            public EqualsCounter Value { get { return Item1; } }
        }
    }
}
