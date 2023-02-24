namespace Yangen
{
    public class FilterRuleLength : IFilterRule
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public FilterRuleLength(int maxLength)
        {
            _minLength = 0;
            _maxLength = maxLength;
        }

        public FilterRuleLength(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public bool IsValidName(Name name)
        {
            return name.Length <= _maxLength && name.Length >= _minLength;
        }
    }

    public static class FilterRuleLengthExtensions
    {
        public static IFilterProcessor WithMaxLength(this IFilterProcessor filter, int maxLength)
        {
            filter.AddFilterRule(new FilterRuleLength(0, maxLength));
            return filter;
        }

        public static IFilterProcessor WithMinLength(this IFilterProcessor filter, int minLength)
        {
            filter.AddFilterRule(new FilterRuleLength(minLength, int.MaxValue));
            return filter;
        }

        public static IFilterProcessor WithLengthRange(this IFilterProcessor filter, int minLength, int maxLength)
        {
            filter.AddFilterRule(new FilterRuleLength(minLength, maxLength));
            return filter;
        }
    }
}