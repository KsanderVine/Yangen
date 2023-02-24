namespace Yangen
{
    public class FilterRuleContains : IFilterRule
    {
        private readonly string _value;
        private readonly bool _inverted;

        public FilterRuleContains(string value, bool inverted)
        {
            _value = value;
            _inverted = inverted;
        }
        public bool IsValidName(Name name)
        {
            return name.ToString().Contains(_value) != _inverted;
        }
    }

    public static class FilterRuleContainsExtensions
    {
        public static IFilterProcessor WhenContains(this IFilterProcessor filter, string value)
        {
            filter.AddFilterRule(new FilterRuleContains(value, false));
            return filter;
        }

        public static IFilterProcessor WhenNotContains(this IFilterProcessor filter, string value)
        {
            filter.AddFilterRule(new FilterRuleContains(value, true));
            return filter;
        }
    }
}
