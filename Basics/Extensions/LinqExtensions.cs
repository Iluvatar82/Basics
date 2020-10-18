using System;
using System.Collections.Generic;

namespace Basics.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// From a Collection, Filter out all Elements that match the <paramref name="filter"/>.
        /// </summary>
        /// <typeparam name="T">Type of the Elements of the Collection.</typeparam>
        /// <param name="collection">Collection of Elements of Type <typeparamref name="T"/>.</param>
        /// <param name="filter">Filter Function that defines, which Elements should be removed from the Collection.</param>
        /// <returns>Collection of remaining Elements that didn't match the Filter Function, default(T) if the Collection is null.</returns>
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            if (collection == null)
                yield return default;

            foreach (var item in collection)
            {
                if (filter(item))
                    continue;

                yield return item;
            }
        }
    }
}