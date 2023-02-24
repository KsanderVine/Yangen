namespace Yangen
{
    public class MutationConditionIfLengthMore : IMutationCondition
    {
        private readonly int _length;

        public MutationConditionIfLengthMore(int length)
        {
            _length = length;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.Length > _length;
        }
    }

    public static class MutationConditionIfLengthMoreExtensions
    {
        public static IMutationSchema IfLengthMore(this IMutationSchema mutationSchema, int length)
        {
            mutationSchema.AddCondition(new MutationConditionIfLengthMore(length));
            return mutationSchema;
        }
    }
}
