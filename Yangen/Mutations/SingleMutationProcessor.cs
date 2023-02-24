namespace Yangen
{
    public class SingleMutationProcessor : IMutationProcessor
    {
        private readonly IMutationSchema _mutationSchema;

        public SingleMutationProcessor(IMutationSchema mutationSchema)
        {
            if (mutationSchema is null)
                throw new ArgumentNullException(nameof(mutationSchema));

            _mutationSchema = mutationSchema;
        }

        public IEnumerable<Name> ProcessNames(IEnumerable<Name> names)
        {
            foreach (var name in names)
            {
                if (_mutationSchema.IsValidName(name))
                {
                    _mutationSchema.ApplyForName(name);
                }
            }
            return names;
        }
    }
}