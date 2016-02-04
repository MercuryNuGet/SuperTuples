namespace SuperTuples
{
    public abstract class Suple<T>
    {
        private readonly T _item1;

        protected Suple(T item1)
        {
            _item1 = item1;
        }

        protected T Item1 { get { return _item1; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var other = obj as Suple<T>;
            if (other == null) return false;
            return _item1.Equals(other._item1);
        }
    }
}
