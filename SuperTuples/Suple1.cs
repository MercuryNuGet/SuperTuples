namespace SuperTuples
{
    public abstract class Suple<T1>
    {
        private readonly T1 _item1;
        private readonly int? _cachedHash;

        protected Suple(T1 item1)
        {
            _item1 = item1;
        }

		protected Suple(T1 item1, SupleHash hashMode)
        {
            _item1 = item1;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
			    return hashcode;
		    }
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
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2)
        {
            _item1 = item1;
            _item2 = item2;
        }

		protected Suple(T1 item1, T2 item2, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ")";
        }
    }

    public abstract class Suple<T1, T2, T3>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2, T3 item3)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
        }

		protected Suple(T1 item1, T2 item2, T3 item3, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2) && Equals(_item3, other._item3);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ", " + SupleHelpers.NullString(_item3) + ")";
        }
    }

    public abstract class Suple<T1, T2, T3, T4>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly T4 _item4;
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
        }

		protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }
        protected T4 Item4 { get { return _item4; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3, T4>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2) && Equals(_item3, other._item3) && Equals(_item4, other._item4);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item4 != null ? _item4.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ", " + SupleHelpers.NullString(_item3) + ", " + SupleHelpers.NullString(_item4) + ")";
        }
    }

    public abstract class Suple<T1, T2, T3, T4, T5>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly T4 _item4;
        private readonly T5 _item5;
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
        }

		protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }
        protected T4 Item4 { get { return _item4; } }
        protected T5 Item5 { get { return _item5; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3, T4, T5>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2) && Equals(_item3, other._item3) && Equals(_item4, other._item4) && Equals(_item5, other._item5);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item4 != null ? _item4.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item5 != null ? _item5.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ", " + SupleHelpers.NullString(_item3) + ", " + SupleHelpers.NullString(_item4) + ", " + SupleHelpers.NullString(_item5) + ")";
        }
    }

    public abstract class Suple<T1, T2, T3, T4, T5, T6>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly T4 _item4;
        private readonly T5 _item5;
        private readonly T6 _item6;
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
        }

		protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }
        protected T4 Item4 { get { return _item4; } }
        protected T5 Item5 { get { return _item5; } }
        protected T6 Item6 { get { return _item6; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3, T4, T5, T6>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2) && Equals(_item3, other._item3) && Equals(_item4, other._item4) && Equals(_item5, other._item5) && Equals(_item6, other._item6);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item4 != null ? _item4.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item5 != null ? _item5.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item6 != null ? _item6.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ", " + SupleHelpers.NullString(_item3) + ", " + SupleHelpers.NullString(_item4) + ", " + SupleHelpers.NullString(_item5) + ", " + SupleHelpers.NullString(_item6) + ")";
        }
    }

    public abstract class Suple<T1, T2, T3, T4, T5, T6, T7>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly T4 _item4;
        private readonly T5 _item5;
        private readonly T6 _item6;
        private readonly T7 _item7;
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
        }

		protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }
        protected T4 Item4 { get { return _item4; } }
        protected T5 Item5 { get { return _item5; } }
        protected T6 Item6 { get { return _item6; } }
        protected T7 Item7 { get { return _item7; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3, T4, T5, T6, T7>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2) && Equals(_item3, other._item3) && Equals(_item4, other._item4) && Equals(_item5, other._item5) && Equals(_item6, other._item6) && Equals(_item7, other._item7);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item4 != null ? _item4.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item5 != null ? _item5.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item6 != null ? _item6.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item7 != null ? _item7.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ", " + SupleHelpers.NullString(_item3) + ", " + SupleHelpers.NullString(_item4) + ", " + SupleHelpers.NullString(_item5) + ", " + SupleHelpers.NullString(_item6) + ", " + SupleHelpers.NullString(_item7) + ")";
        }
    }

    public abstract class Suple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private readonly T1 _item1;
        private readonly T2 _item2;
        private readonly T3 _item3;
        private readonly T4 _item4;
        private readonly T5 _item5;
        private readonly T6 _item6;
        private readonly T7 _item7;
        private readonly T8 _item8;
        private readonly int? _cachedHash;

        protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _item8 = item8;
        }

		protected Suple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, T8 item8, SupleHash hashMode)
        {
            _item1 = item1;
            _item2 = item2;
            _item3 = item3;
            _item4 = item4;
            _item5 = item5;
            _item6 = item6;
            _item7 = item7;
            _item8 = item8;
            _cachedHash = CalculateHashCode();
        }

        protected T1 Item1 { get { return _item1; } }
        protected T2 Item2 { get { return _item2; } }
        protected T3 Item3 { get { return _item3; } }
        protected T4 Item4 { get { return _item4; } }
        protected T5 Item5 { get { return _item5; } }
        protected T6 Item6 { get { return _item6; } }
        protected T7 Item7 { get { return _item7; } }
        protected T8 Item8 { get { return _item8; } }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            var other = (Suple<T1, T2, T3, T4, T5, T6, T7, T8>) obj;
            if (_cachedHash != null &&
                other._cachedHash != null &&
                _cachedHash != other._cachedHash) return false;
            return Equals(_item1, other._item1) && Equals(_item2, other._item2) && Equals(_item3, other._item3) && Equals(_item4, other._item4) && Equals(_item5, other._item5) && Equals(_item6, other._item6) && Equals(_item7, other._item7) && Equals(_item8, other._item8);
        }

        public override int GetHashCode()
        {
			return _cachedHash ?? CalculateHashCode();
        }

        private int CalculateHashCode()
        {
		    unchecked
			{
		        int hashcode = 0;
                hashcode += _item1 != null ? _item1.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item2 != null ? _item2.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item3 != null ? _item3.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item4 != null ? _item4.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item5 != null ? _item5.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item6 != null ? _item6.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item7 != null ? _item7.GetHashCode() : 0;
                hashcode *= 31;
                hashcode += _item8 != null ? _item8.GetHashCode() : 0;
			    return hashcode;
		    }
        }

        public override string ToString()
        {
            return "(" + SupleHelpers.NullString(_item1) + ", " + SupleHelpers.NullString(_item2) + ", " + SupleHelpers.NullString(_item3) + ", " + SupleHelpers.NullString(_item4) + ", " + SupleHelpers.NullString(_item5) + ", " + SupleHelpers.NullString(_item6) + ", " + SupleHelpers.NullString(_item7) + ", " + SupleHelpers.NullString(_item8) + ")";
        }
    }

}