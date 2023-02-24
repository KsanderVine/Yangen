namespace Yangen
{
    public class MutationConditionIfLengthLessOrEqual : IMutationCondition
    {
        private readonly int _length;

        public MutationConditionIfLengthLessOrEqual(int length)
        {
            _length = length;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.Length <= _length;
        }
    }

    public static class MutationConditionIfLengthLessOrEqualExtensions
    {
        public static IMutationSchema IfLengthLessOrEqual(this IMutationSchema mutationSchema, int length)
        {
            mutationSchema.AddCondition(new MutationConditionIfLengthLessOrEqual(length));
            return mutationSchema;
        }
    }
}
