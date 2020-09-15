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

        public static IEnumerable<T> CastTo<TBase, T>(this IEnumerable<TBase> baseEnumerable) where T : TBase
        {
            foreach (var item in baseEnumerable)
                yield return (T)item;
        }

        public static IEnumerable<TBase> CastTo<TBase, T>(this IEnumerable<T> derivedEnumerable) where T : TBase
        {
            foreach (var item in derivedEnumerable)
                yield return item;
        }
    }
}