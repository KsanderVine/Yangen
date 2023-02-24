namespace Yangen
{
    public static class GeneratorProcessorExtensions
    {
        public static ISource AddGenerator(
            this ISource source,
            IGeneratorProcessor generatorProcessor)
        {
            source.AddProcessor(generatorProcessor);
            return source;
        }

        public static ISource AddGenerator(
            this ISource source,
            IGenerator generator,
            int poolSize = 1000)
        {
            var generatorProcessor = new GeneratorProcessor()
                .UsingGenerator(generator)
                .WithPoolSize(poolSize);

            source.AddProcessor(generatorProcessor);
            return source;
        }

        public static ISource AddGenerator<TGenerator>(
            this ISource source,
            Func<TGenerator, TGenerator> configure,
            int poolSize = 1000) where TGenerator : IGenerator
        {
            var generator = Activator.CreateInstance<TGenerator>();
            generator = configure(generator);

            var generatorProcessor = new GeneratorProcessor()
                .UsingGenerator(generator)
                .WithPoolSize(poolSize);

            source.AddProcessor(generatorProcessor);
            return source;
        }

        public static ISource AddGenerator<TGenerator, TGeneratorProcessor>(
            this ISource source,
            Func<TGenerator, TGenerator> configureGenerator,
            Func<TGeneratorProcessor, TGeneratorProcessor> configureProcessor)
            where TGenerator : IGenerator
            where TGeneratorProcessor : IGeneratorProcessor
        {
            var generatorProcessor = Activator.CreateInstance<TGeneratorProcessor>();
            generatorProcessor = configureProcessor(generatorProcessor);

            var generator = Activator.CreateInstance<TGenerator>();
            generator = configureGenerator(generator);

            generatorProcessor.UsingGenerator(generator);

            source.AddProcessor(generatorProcessor);
            return source;
        }
    }
}