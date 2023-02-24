namespace Yangen
{
    public class SwitchMutationProcessor : IMutationProcessor
    {
        private readonly IMutationSchema[] _mutationSchemas;

        public SwitchMutationProcessor(IMutationSchema[] mutationSchemas)
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
                if (GetBestSchemaForName(name) is MutationSchema mutationSchema)
                {
                    mutationSchema.ApplyForName(name);
                }
            }

            return names;

            IMutationSchema? GetBestSchemaForName(Name name)
            {
                foreach (var mutationSchema in _mutationSchemas)
                {
                    if (mutationSchema.IsValidName(name))
                    {
                        return mutationSchema;
                    }
                }

                return null;
            }
        }
    }
}