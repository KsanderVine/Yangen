using System.Text.RegularExpressions;

namespace Yangen
{
    public class MutationActionForMatch : IMutationAction
    {
        private readonly Regex _regex;
        private readonly Action<IMutationSchema, MatchResult> _configuration;

        public MutationActionForMatch(string pattern, Action<IMutationSchema, MatchResult> configuration)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException($"Value of {nameof(pattern)} can not be null, empty or write space");

            if (configuration is null)
                throw new ArgumentNullException(nameof(configuration));

            _regex = new Regex(pattern);
            _configuration = configuration;
        }

        public void ApplyForName(Name name)
        {
            Match match = _regex.Match(name.ToString());

            if (match.Success)
            {
                MutationSchema mutationSchema = new();
                MatchResult result = new(0, match);

                _configuration(mutationSchema, result);

                if (mutationSchema.IsValidName(name))
                {
                    mutationSchema.ApplyForName(name);
                }
            }
        }
    }

    public static class MutationActionForMatchExtensions
    {
        public static IMutationSchema ForMatch(this IMutationSchema mutationSchema, string pattern, Action<IMutationSchema, MatchResult> configuration)
        {
            mutationSchema.AddAction(new MutationActionForMatch(pattern, configuration));
            return mutationSchema;
        }
    }
}
