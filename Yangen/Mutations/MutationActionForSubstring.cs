namespace Yangen
{
    public class MutationActionForSubstring : IMutationAction
    {
        private readonly string _value;
        private readonly Action<IMutationSchema, SubstringResult> _configuration;

        public MutationActionForSubstring(string value, Action<IMutationSchema, SubstringResult> configuration)
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
            int position = name.Value.ToString().IndexOf(_value);

            if (position != -1)
            {
                SubstringResult result = new(0, position);
                MutationSchema mutationSchema = new();
                _configuration(mutationSchema, result);

                if (mutationSchema.IsValidName(name))
                {
                    mutationSchema.ApplyForName(name);
                }
            }
        }
    }

    public static class MutationActionForSubstringExtensions
    {
        public static IMutationSchema ForSubstring(this IMutationSchema mutationSchema, string value, Action<IMutationSchema, SubstringResult> configuration)
        {
            mutationSchema.AddAction(new MutationActionForSubstring(value, configuration));
            return mutationSchema;
        }
    }
}
