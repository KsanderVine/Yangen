namespace Yangen
{
    public class MutationConditionIfLengthMoreOrEqual : IMutationCondition
    {
        private readonly int _length;

        public MutationConditionIfLengthMoreOrEqual(int length)
        {
            _length = length;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.Length >= _length;
        }
    }

    public static class MutationConditionIfLengthMoreOrEqualExtensions
    {
        public static IMutationSchema IfLengthMoreOrEqual(this IMutationSchema mutationSchema, int length)
        {
            mutationSchema.AddCondition(new MutationConditionIfLengthMoreOrEqual(length));
            return mutationSchema;
        }
    }
}
