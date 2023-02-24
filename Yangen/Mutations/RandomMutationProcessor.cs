using Yangen.Extenstions;

namespace Yangen
{
    public class RandomMutationProcessor : IMutationProcessor
    {
        private readonly IMutationSchema[] _mutationSchemas;

        public RandomMutationProcessor(IMutationSchema[] mutationSchemas)
        {
            if (mutationSchemas is null)
                throw new ArgumentNullException(nameof(mutationSchemas));

            if (mutationSchemas.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(mutationSchemas));

            _mutationSchemas = mutationSchemas;
        }

        public IEnumerable<Name> ProcessNames(IEnumerable<Name> names)
        {
            foreach (var name in names)
            {
                if (_mutationSchemas.GetRandomItem() is IMutationSchema mutationSchema)
                {
                    if (mutationSchema.IsValidName(name))
                    {
                        mutationSchema.ApplyForName(name);
                    }
                }
            }
            return names;
        }
    }
}