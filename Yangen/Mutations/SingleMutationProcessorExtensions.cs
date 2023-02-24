namespace Yangen
{
    public static class SingleMutationProcessorExtensions
    {
        public static ISource AddMutation(
            this ISource source,
            IMutationSchema mutation)
        {
            var mutationProcessor = new SingleMutationProcessor(mutation);

            source.AddProcessor(mutationProcessor);
            return source;
        }

        public static ISource AddMutation(
            this ISource source,
            Func<IMutationSchema, IMutationSchema> configure)
        {
            var mutation = configure(new MutationSchema());
            var mutationProcessor = new SingleMutationProcessor(mutation);

            source.AddProcessor(mutationProcessor);
            return source;
        }
    }
}