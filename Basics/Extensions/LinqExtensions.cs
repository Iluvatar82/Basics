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

        /// <summary>
        /// Converts an <paramref name="item"/> to an Enumerable of Type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of the Item.</typeparam>
        /// <param name="item">The Item to create an Enumerable from.</param>
        /// <returns>Enumerable representing the single <paramref name="item"/>.</returns>
        public static IEnumerable<T> ItemToEnumerable<T>(this T item)
        {
            yield return item;
        }

        /// <summary>
        /// Converts an <paramref name="item"/> to a <see cref="List{T}"/> of Type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of the Item.</typeparam>
        /// <param name="item">The Item to create an Enumerable from.</param>
        /// <returns>Enumerable representing the single <paramref name="item"/>.</returns>
        public static List<T> ItemToList<T>(this T item) => new List<T> { item };

        /// <summary>
        /// Repeats a single <paramref name="item"/> multiple <paramref name="repetitions"/> and creates an Enumerable.
        /// </summary>
        /// <typeparam name="T">Type of the Element.</typeparam>
        /// <param name="item">The Item to create an Enumerable from.</param>
        /// <param name="repetitions">The number of Repititions wanted.</param>
        /// <returns>Enumerable representing the <paramref name="item"/> multiple times.</returns>
        public static IEnumerable<T> Repeat<T>(this T item, int repetitions)
        {
            if (repetitions < 1)
                yield break;

            for (var i = 0; i < repetitions; i++)
                yield return item;
        }
    }
}