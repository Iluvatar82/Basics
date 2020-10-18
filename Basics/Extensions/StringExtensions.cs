namespace Basics.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Trim Occurrences of the String <paramref name="toRemove"/> from the Start of the String <paramref name="baseString"/>.
        /// </summary>
        /// <param name="baseString">The String to be trimmed.</param>
        /// <param name="toRemove">The String to be removed from the Start of the String <paramref name="baseString"/>.</param>
        /// <returns>String without any Occurrences of <paramref name="toRemove"/> at the Start.</returns>
        public static string TrimStart(this string baseString, string toRemove)
        {
            if (string.IsNullOrWhiteSpace(baseString))
                return baseString;

            if (string.IsNullOrEmpty(toRemove))
                return baseString;

            var length = toRemove.Length;
            var currentIndex = 0;
            var removeIndex = 0;
            var result = baseString;
            for (int i = 0; i < baseString.Length; i++)
            {
                var same = baseString[i].Equals(toRemove[removeIndex]);
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

        /// <summary>
        /// Trim Occurrences of the String <paramref name="toRemove"/> from the End of the String <paramref name="baseString"/>.
        /// </summary>
        /// <param name="baseString">The String to be trimmed.</param>
        /// <param name="toRemove">The String to be removed from the End of the String <paramref name="baseString"/>.</param>
        /// <returns>String without any Occurrences of <paramref name="toRemove"/> at the End.</returns>
        public static string TrimEnd(this string baseString, string toRemove)
        {
            if (string.IsNullOrWhiteSpace(baseString))
                return baseString;

            if (string.IsNullOrEmpty(toRemove))
                return baseString;

            var length = toRemove.Length;
            var currentIndex = baseString.Length;
            var removeIndex = length - 1;
            var result = baseString;
            for (int i = baseString.Length - 1; i >= 0; i--)
            {
                var same = baseString[i].Equals(toRemove[removeIndex]);
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

        /// <summary>
        /// Trim Occurrences of the String <paramref name="toRemove"/> from the Start and the End of the String <paramref name="baseString"/>.
        /// </summary>
        /// <param name="baseString">The String to be trimmed.</param>
        /// <param name="toRemove">The String to be removed from the Start and the End of the String <paramref name="baseString"/>.</param>
        /// <returns>String without any Occurrences of <paramref name="toRemove"/> at the Start and the End.</returns>
        public static string Trim(this string baseString, string stringToRemove)
        {
            if (string.IsNullOrWhiteSpace(baseString))
                return baseString;

            if (string.IsNullOrEmpty(stringToRemove))
                return baseString;

            return baseString.TrimStart(stringToRemove).TrimEnd(stringToRemove);
        }

        /// <summary>
        /// Capitalizes every word in the String <paramref name="baseString"/>.
        /// </summary>
        /// <param name="baseString">The String to be capitalized.</param>
        /// <returns>Capitalized String.</returns>
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

        /// <summary>
        /// Decorates the String <paramref name="baseString"/> at the Start and the End with an additional Character <paramref name="decorator"/>.
        /// </summary>
        /// <param name="baseString">The String to be decorated.</param>
        /// <param name="decorator">The Decorator Character.</param>
        /// <returns>Decorated String.</returns>
        public static string DecorateStartEnd(this string baseString, char decorator) => decorator + baseString + decorator;

        /// <summary>
        /// Decorates the String <paramref name="baseString"/> at the Start and the End with another String <paramref name="decorator"/>.
        /// </summary>
        /// <param name="baseString">The String to be decorated.</param>
        /// <param name="decorator">The Decorator String.</param>
        /// <returns>Decorated String.</returns>
        public static string DecorateStartEnd(this string baseString, string decorator) => decorator + baseString + decorator;

        /// <summary>
        /// Creates SQL Strings from the Input String <paramref name="sqlValue"/>.
        /// </summary>
        /// <param name="sqlValue">The Input String.</param>
        /// <returns>SQL Version of the Input String.</returns>
        public static string SQLStringify(this string sqlValue) => DecorateStartEnd(sqlValue, '\'');
    }
}