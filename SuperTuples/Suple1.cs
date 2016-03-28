namespace SuperTuples
{
    public abstract class Suple<T1>
    {
        private readonly T1 _item1;

        protected Suple(T1 item1)
        {
            _item1 = item1;
        }

        protected T1 Item1 { get { return _item1; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as Suple<T1>;
            if (other == null) return false;
            return Equals(_item1, other._item1);
        }

        public override int GetHashCode()
        {
		    int hashcode = 0;
            hashcode += _item1 != null ? _item1.GetHashCode() : 0;
			return hashcode;
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ")";
        }
    }

    public abstract class Suple<T1, T2>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;

        protected Suple(T1 item1, T2 item2)
        {
            _item1 = item1;
            _item2 = item2;
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = obj as Suple<T1, T2>;
            if (other == null) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2);
        }

        public override int GetHashCode()
        {
		    int hashcode = 0;
            hashcode += _item1 != null ? _item1.GetHashCode() : 0;
            hashcode *= 31;
            hashcode += _item2 != null ? _item2.GetHashCode() : 0;
			return hashcode;
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ")";
        }
    }

}