namespace Yangen
{
    public class FilterRuleStartsWith : IFilterRule
    {
        private readonly string _value;
        private readonly bool _inverted;

        public FilterRuleStartsWith(string value, bool inverted)
        {
            _value = value;
            _inverted = inverted;
        }
        public bool IsValidName(Name name)
        {
            return name.ToString().StartsWith(_value) != _inverted;
        }
    }

    public static class FilterRuleStartsWithExtensions
    {
        public static IFilterProcessor WhenStartsWith(this IFilterProcessor filter, string value)
        {
            filter.AddFilterRule(new FilterRuleStartsWith(value, false));
            return filter;
        }

        public static IFilterProcessor WhenNotStartsWith(this IFilterProcessor filter, string value)
        {
            filter.AddFilterRule(new FilterRuleStartsWith(value, true));
            return filter;
        }
    }
}
