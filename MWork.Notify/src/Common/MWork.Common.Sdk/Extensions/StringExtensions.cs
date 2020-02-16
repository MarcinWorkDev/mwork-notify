using System.Text;

namespace MWork.Common.Sdk.Extensions
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

        public static string Underscore(this string str)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < str.Length; ++i)
            {
                if (ShouldUnderscore(i, str))
                {
                    builder.Append('_');
                }

                builder.Append(char.ToLowerInvariant(str[i]));
            }

            return builder.ToString();
        }
 
        private static bool ShouldUnderscore(int i, string s)
        {
            if (i == 0 || i >= s.Length || s[i] == '_') return false;

            var curr = s[i];
            var prev = s[i - 1];
            var next = i < s.Length - 2 ? s[i + 1] : '_';

            return prev != '_' && ((char.IsUpper(curr) && (char.IsLower(prev) || char.IsLower(next))) ||
                                   (char.IsNumber(curr) && (!char.IsNumber(prev))));
        }
    }
}