using Yangen.Extenstions;

namespace Yangen
{
    public class MutationActionForSubstrings : IMutationAction
    {
        private readonly string _value;
        private readonly Action<IMutationSchema, SubstringResult> _configuration;

        public MutationActionForSubstrings(string value, Action<IMutationSchema, SubstringResult> configuration)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"Value of {nameof(value)} can not be null, empty or write space");

            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            _value = value;
            _configuration = configuration;
        }

        public void ApplyForName(Name name)
        {
            var indecies = name.Value.ToString().AllIndexesOf(_value);

            foreach ((int index, var position) in indecies.Select((x, i) => (i, x)))
            {
                if (position != -1)
                {
                    SubstringResult result = new(index, position);
                    MutationSchema mutationSchema = new();
                    _configuration(mutationSchema, result);

                    if (mutationSchema.IsValidName(name))
                    {
                        mutationSchema.ApplyForName(name);
                    }
                }
            }
        }
    }

    public static class MutationActionForSubstringsExtensions
    {
        public static IMutationSchema ForSubstrings(this IMutationSchema mutationSchema, string value, Action<IMutationSchema, SubstringResult> configuration)
        {
            mutationSchema.AddAction(new MutationActionForSubstrings(value, configuration));
            return mutationSchema;
        }
    }
}
