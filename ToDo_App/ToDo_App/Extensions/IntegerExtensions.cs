namespace ToDo_App.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsBetween(this int num, int lower, int upper, bool inclusive = false)
        {
            return inclusive
                ? lower <= num && num <= upper
                : lower < num && num < upper;
        }
    }
}