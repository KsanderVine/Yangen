namespace Yangen.Extenstions
{
    internal static class ListExtensions
    {
        private static readonly Random _random = new();

        public static T? GetRandomItem<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                return default;
            }
            else
            {
                int selection = _random.Next(list.Count);

                return list[selection];
            }
        }

        public static T? GetRandomItem<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.ToList().GetRandomItem();
        }

        public static T? GetRandomItem<T>(this ISet<T> set)
        {
            return set.ToList().GetRandomItem();
        }

        public static TResult SelectAs<TSource, TResult>(this TSource source, Func<TSource, TResult> selector) => selector(source);
    }
}
