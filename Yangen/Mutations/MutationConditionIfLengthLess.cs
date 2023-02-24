namespace Yangen
{
    public class MutationConditionIfLengthLess : IMutationCondition
    {
        private readonly int _length;

        public MutationConditionIfLengthLess(int length)
        {
            _length = length;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.Length < _length;
        }
    }

    public static class MutationConditionIfLengthLessExtensions
    {
        public static IMutationSchema IfLengthLess(this IMutationSchema mutationSchema, int length)
        {
            mutationSchema.AddCondition(new MutationConditionIfLengthLess(length));
            return mutationSchema;
        }
    }
}
