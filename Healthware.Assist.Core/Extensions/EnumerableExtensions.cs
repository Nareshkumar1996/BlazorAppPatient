using System;
using System.Collections.Generic;
using System.Linq;

namespace Healthware.Assist.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static T AtIndex<T>(this IEnumerable<T> itemsToPeekInto, int indexToPeekAt)
        {
            return new List<T>(itemsToPeekInto)[indexToPeekAt];
        }

        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return !source.Any(predicate);
        }

        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items ?? new List<T>()) action(item);
        }

        public static IEnumerable<T> intercept<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items ?? new List<T>())
            {
                action(item);
                yield return item;
            }
        }

        public static bool does_not_contain<T>(this IEnumerable<T> items, T item)
        {
            return !items.Contains(item);
        }

        public static IEnumerable<T> merge_with<T>(this IEnumerable<T> left, IEnumerable<T> right)
        {
            return left.Union(right);
        }

        public static bool isNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }

        public static IEnumerable<T> or_empty<T>(this IEnumerable<T> items)
        {
            return items ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> target, params T[] itemsToRemove)
        {
            return target.Remove(itemsToRemove);
        }

        public static IEnumerable<T> Remove<T>(this IEnumerable<T> target, IEnumerable<T> itemsToRemove)
        {
            return target.Where(item => !itemsToRemove.Contains(item));
        }

        public static bool Contains<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            return items.All(x => source.Contains(x));
        }

        public static bool ContainsAnyOf<T>(this IEnumerable<T> source, IEnumerable<T> items)
        {
            return source.Intersect(items).Any();
        }

	    public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> items)
	    {
		    return items ?? Enumerable.Empty<T>();
	    }

	    public static string Join<T>(this IEnumerable<T> items, string separator)
	    {
		    return string.Join(separator, items.Select(x => x == null ? string.Empty : x.ToString()).ToArray());
	    }
	}
}