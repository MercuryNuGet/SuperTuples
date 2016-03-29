namespace SuperTuples
{
    internal static class SupleHelpers
    {
        public static string NullString(object item)
        {
            return item != null ? item.ToString() : "null";
        }
    }
}
