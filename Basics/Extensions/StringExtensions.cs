namespace Basics.Extensions
{
    public static class StringExtensions
    {
        public static string TrimStart(this string basicString, string stringToRemove)
        {
            if (string.IsNullOrWhiteSpace(basicString))
                return basicString;

            if (string.IsNullOrEmpty(stringToRemove))
                return basicString;

            var length = stringToRemove.Length;
            var currentIndex = 0;
            var removeIndex = 0;
            var result = basicString;
            for (int i = 0; i < basicString.Length; i++)
            {
                var same = basicString[i].Equals(stringToRemove[removeIndex]);
                if (same && removeIndex == length - 1)
                {
                    currentIndex += length;
                    removeIndex = 0;
                    continue;
                }
                else if (same)
                {
                    removeIndex++;
                    continue;
                }

                break;
            }

            return result.Substring(currentIndex);
        }

        public static string TrimEnd(this string basicString, string stringToRemove)
        {
            if (string.IsNullOrWhiteSpace(basicString))
                return basicString;

            if (string.IsNullOrEmpty(stringToRemove))
                return basicString;

            var length = stringToRemove.Length;
            var currentIndex = basicString.Length;
            var removeIndex = length - 1;
            var result = basicString;
            for (int i = basicString.Length - 1; i >= 0; i--)
            {
                var same = basicString[i].Equals(stringToRemove[removeIndex]);
                if (same && removeIndex == 0)
                {
                    currentIndex -= length;
                    removeIndex = length - 1;
                    continue;
                }
                else if (same)
                {
                    removeIndex--;
                    continue;
                }

                break;
            }

            return result.Substring(0, currentIndex);
        }

        public static string Trim(this string basicString, string stringToRemove)
        {
            if (string.IsNullOrWhiteSpace(basicString))
                return basicString;

            if (string.IsNullOrEmpty(stringToRemove))
                return basicString;

            return basicString.TrimStart(stringToRemove).TrimEnd(stringToRemove);
        }

        public static string CapitalizeFirstCharacter(this string baseString)
        {
            if (string.IsNullOrWhiteSpace(baseString))
                return baseString;

            var result = new char[baseString.Length];
            var isFirstCharacter = true;
            for(var i = 0; i < baseString.Length; i++)
            {
                if (isFirstCharacter)
                    result[i] = char.ToUpperInvariant(baseString[i]);
                else
                    result[i] = baseString[i];

                isFirstCharacter = char.IsWhiteSpace(baseString[i]);
            }

            return new string(result);
        }

        public static string DecorateStartEnd(this string toDecorate, char decorator) => decorator + toDecorate + decorator;

        public static string DecorateStartEnd(this string toDecorate, string decorator) => decorator + toDecorate + decorator;

        public static string SQLStringify(this string sqlValue) => DecorateStartEnd(sqlValue, '\'');
    }
}