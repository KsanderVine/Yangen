using System.Text.RegularExpressions;

namespace Yangen
{
    public class FilterRuleRegexPatterns : IFilterRule
    {
        private readonly List<Regex> _regexList;
        private readonly bool _allowMatched;

        public FilterRuleRegexPatterns(bool allowMatched, params string[] patterns)
        {
            _allowMatched = allowMatched;
            _regexList = new List<Regex>();

            foreach (var pattern in patterns)
            {
                _regexList.Add(new Regex(pattern, RegexOptions.Singleline));
            }
        }

        public bool IsValidName(Name name)
        {
            return (IsMatchAnyPattern(name) == _allowMatched);
        }

        private bool IsMatchAnyPattern(Name name)
        {
            bool isMatch = false;
            string nameString = name.ToString();

            foreach (var regex in _regexList)
            {
                if (regex.IsMatch(nameString))
                {
                    isMatch = true;
                    break;
                }
            }
            return isMatch;
        }
    }

    public static class FilterRuleRegexPatternsExtensions
    {
        public static IFilterProcessor WhenMatchPattern(this IFilterProcessor filter, params string[] patterns)
        {
            filter.AddFilterRule(new FilterRuleRegexPatterns(true, patterns));
            return filter;
        }

        public static IFilterProcessor WhenNotMatchPattern(this IFilterProcessor filter, params string[] patterns)
        {
            filter.AddFilterRule(new FilterRuleRegexPatterns(false, patterns));
            return filter;
        }
    }
}