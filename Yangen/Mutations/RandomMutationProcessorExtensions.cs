namespace Yangen
{
    public static class RandomMutationProcessorExtensions
    {
        public static ISource AddMutationRandom(
        this ISource source,
        params IMutationSchema[] mutations)
        {
            var mutationProcessor = new RandomMutationProcessor(mutations);

            source.AddProcessor(mutationProcessor);
            return source;
        }

        public static ISource AddMutationRandom(
            this ISource source,
            params Func<IMutationSchema, IMutationSchema>[] configurations)
        {
            var mutations = GetSchemas().ToArray();
            var mutationProcessor = new RandomMutationProcessor(mutations);

            source.AddProcessor(mutationProcessor);
            return source;

            IEnumerable<IMutationSchema> GetSchemas()
            {
                foreach (var configure in configurations)
                {
                    yield return configure(new MutationSchema());
                }
            }
        }
    }
}