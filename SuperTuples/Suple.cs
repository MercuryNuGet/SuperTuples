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
            if (GetType() != obj.GetType()) return false;
            var other = obj as Suple<T>;
            if (other == null) return false;
            return Equals(_item1, other._item1);
        }

        public override int GetHashCode()
        {
            return _item1 != null ? _item1.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return "(" + (_item1 != null ? _item1.ToString() : "null") + ")";
        }
    }
}
