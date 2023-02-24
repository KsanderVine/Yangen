namespace Yangen
{
    public class GeneratorProcessor : IGeneratorProcessor
    {
        private IGenerator? Generator { get; set; }
        private List<string>? Pool { get; set; }
        private int PoolSize { get; set; } = 1000;

        public IGeneratorProcessor UsingGenerator(IGenerator generator)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
            return this;
        }

        public IGeneratorProcessor WithPoolSize(int poolSize)
        {
            if (poolSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(poolSize), $"{nameof(poolSize)} must be more then zero");

            PoolSize = poolSize;
            return this;
        }

        public IEnumerable<Name> ProcessNames(IEnumerable<Name> names)
        {
            var namesList = new List<Name>(names);
            namesList.AddRange(GenerateOrReturn().Select(n => new Name(n)));
            return namesList;
        }

        private IEnumerable<string> GenerateOrReturn()
        {
            return Pool is not null ? Pool : GeneratePool();
        }

        private IEnumerable<string> GeneratePool()
        {
            if (Generator == null)
                throw new NullReferenceException("Generator not provided");

            List<string> pool = new();

            while (pool.Count < PoolSize)
            {
                if (Generator.Next() is string name)
                {
                    pool.Add(name);
                }
                else
                {
                    throw new NullReferenceException("Generator results with null value");
                }
            }

            Pool = pool;
            return pool;
        }
    }
}