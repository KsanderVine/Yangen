namespace Yangen
{
    public class MutationConditionStartsWith : IMutationCondition
    {
        private readonly string _value;
        private readonly bool _inverted;

        public MutationConditionStartsWith(string value, bool inverted)
        {
            _value = value;
            _inverted = inverted;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.ToString().StartsWith(_value) != _inverted;
        }
    }

    public static class MutationConditionWhenStartWithExtensions
    {
        public static IMutationSchema IfStartsWith(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddCondition(new MutationConditionStartsWith(value, false));
            return mutationSchema;
        }

        public static IMutationSchema IfNotStartsWith(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddCondition(new MutationConditionStartsWith(value, true));
            return mutationSchema;
        }
    }
}
