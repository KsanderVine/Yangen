namespace Yangen
{
    public class MutationConditionContains : IMutationCondition
    {
        private readonly string _value;
        private readonly bool _inverted;

        public MutationConditionContains(string value, bool inverted)
        {
            _value = value;
            _inverted = inverted;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.ToString().Contains(_value) != _inverted;
        }
    }

    public static class MutationConditionWhenContaintsExtensions
    {
        public static IMutationSchema IfContains(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddCondition(new MutationConditionContains(value, false));
            return mutationSchema;
        }

        public static IMutationSchema IfNotContains(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddCondition(new MutationConditionContains(value, true));
            return mutationSchema;
        }
    }
}
