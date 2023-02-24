using System.Text.RegularExpressions;

namespace Yangen
{
    public class MutationActionForMatches : IMutationAction
    {
        private readonly Regex _regex;
        private readonly Action<IMutationSchema, MatchResult> _configuration;

        public MutationActionForMatches(string pattern, Action<IMutationSchema, MatchResult> configuration)
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
            MatchCollection matches = _regex.Matches(name.ToString());

            foreach ((int index, Match match) in matches.Select((x, i) => (i, x)))
            {
                MutationSchema mutationSchema = new();
                MatchResult result = new(index, match);

                _configuration(mutationSchema, result);

                if (mutationSchema.IsValidName(name))
                {
                    mutationSchema.ApplyForName(name);
                }
            }
        }
    }

    public static class MutationActionForMatchesExtensions
    {
        public static IMutationSchema ForMatches(this IMutationSchema mutationSchema, string pattern, Action<IMutationSchema, MatchResult> configuration)
        {
            mutationSchema.AddAction(new MutationActionForMatches(pattern, configuration));
            return mutationSchema;
        }
    }
}
