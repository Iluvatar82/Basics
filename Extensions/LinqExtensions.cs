using System;
using System.Collections.Generic;

namespace Basics.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> baseEnumerable, Func<T, bool> filterFunction)
        {
            foreach (var item in baseEnumerable)
            {
                if (filterFunction(item))
                    continue;

                yield return item;
            }
        }
    }
}