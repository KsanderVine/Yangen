using System.Text.RegularExpressions;

namespace Yangen
{
    public class MutationConditionRegexMatch : IMutationCondition
    {
        private readonly Regex _regex;
        private readonly bool _inverted;

        public MutationConditionRegexMatch(string pattern, bool inverted)
        {
            _regex = new Regex(pattern);
            _inverted = inverted;
        }

        public bool IsValidName(Name name)
        {
            return _regex.IsMatch(name.ToString()) != _inverted;
        }
    }

    public static class MutationConditionRegexMatchExtensions
    {
        public static IMutationSchema IfMatch(this IMutationSchema mutationSchema, string pattern)
        {
            mutationSchema.AddCondition(new MutationConditionRegexMatch(pattern, false));
            return mutationSchema;
        }

        public static IMutationSchema IfNotMatch(this IMutationSchema mutationSchema, string pattern)
        {
            mutationSchema.AddCondition(new MutationConditionRegexMatch(pattern, true));
            return mutationSchema;
        }
    }
}
