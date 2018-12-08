namespace Orarend_osszerako.Validation
{
    public static class Required
    {
        public static bool IsValid(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
