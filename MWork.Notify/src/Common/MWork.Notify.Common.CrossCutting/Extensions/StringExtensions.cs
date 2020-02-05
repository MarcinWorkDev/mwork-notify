namespace MWork.Notify.Common.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static bool IsMissing(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsPresent(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }
    }
}