namespace Yangen
{
    public class MutationConditionEndsWith : IMutationCondition
    {
        private readonly string _value;
        private readonly bool _inverted;

        public MutationConditionEndsWith(string value, bool inverted)
        {
            _value = value;
            _inverted = inverted;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.ToString().EndsWith(_value) != _inverted;
        }
    }

    public static class MutationConditionWhenEndWithExtensions
    {
        public static IMutationSchema IfEndsWith(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddCondition(new MutationConditionEndsWith(value, false));
            return mutationSchema;
        }

        public static IMutationSchema IfNotEndsWith(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddCondition(new MutationConditionEndsWith(value, true));
            return mutationSchema;
        }
    }
}
