namespace Yangen
{
    public class FilterRuleEndsWith : IFilterRule
    {
        private readonly string _value;
        private readonly bool _inverted;

        public FilterRuleEndsWith(string value, bool inverted)
        {
            _value = value;
            _inverted = inverted;
        }
        public bool IsValidName(Name name)
        {
            return name.ToString().EndsWith(_value) != _inverted;
        }
    }

    public static class FilterRuleEndsWithExtensions
    {
        public static IFilterProcessor WhenEndsWith(this IFilterProcessor filter, string value)
        {
            filter.AddFilterRule(new FilterRuleEndsWith(value, false));
            return filter;
        }

        public static IFilterProcessor WhenNotEndsWith(this IFilterProcessor filter, string value)
        {
            filter.AddFilterRule(new FilterRuleEndsWith(value, true));
            return filter;
        }
    }
}
