namespace Yangen
{
    public static class SwitchMutationProcessorExtensions
    {
        public static ISource AddMutationSwitch(
        this ISource source,
        params IMutationSchema[] mutations)
        {
            var mutationProcessor = new SwitchMutationProcessor(mutations);

            source.AddProcessor(mutationProcessor);
            return source;
        }

        public static ISource AddMutationSwitch(
            this ISource source,
            params Func<IMutationSchema, IMutationSchema>[] configurations)
        {
            var mutations = GetSchemas().ToArray();
            var mutationProcessor = new SwitchMutationProcessor(mutations);

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