namespace Yangen
{
    public static class NamesEnumProcessorExtensions
    {
        public static ISource AddNames(this ISource source, IEnumerable<string> names)
        {
            var storageProcessor = new NamesEnumProcessor(names);
            source.AddProcessor(storageProcessor);
            return source;
        }

        public static ISource AddNames(this ISource source, params string[] names)
        {
            var storageProcessor = new NamesEnumProcessor(names);
            source.AddProcessor(storageProcessor);
            return source;
        }
    }
}
