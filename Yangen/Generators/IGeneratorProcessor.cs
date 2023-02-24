namespace Yangen
{
    public interface IGeneratorProcessor : ISourceProcessor
    {
        public IGeneratorProcessor UsingGenerator(IGenerator generator);
        public IGeneratorProcessor WithPoolSize(int poolSize);
    }
}