namespace Yangen
{
    public static class FilterProcessorExtensions
    {
        public static ISource AddFilter(
            this ISource source,
            IFilterProcessor filter)
        {
            source.AddProcessor(filter);
            return source;
        }

        public static ISource AddFilter(
            this ISource source,
            Func<IFilterProcessor, IFilterProcessor> configure)
        {
            var filter = configure(new FilterProcessor());
            source.AddProcessor(filter);
            return source;
        }
    }
}