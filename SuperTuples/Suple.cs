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
    }
}
