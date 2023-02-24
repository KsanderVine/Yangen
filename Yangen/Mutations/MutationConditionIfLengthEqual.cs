namespace Yangen
{
    public class MutationConditionIfLengthEqual : IMutationCondition
    {
        private readonly int _length;

        public MutationConditionIfLengthEqual(int length)
        {
            _length = length;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.Length == _length;
        }
    }

    public static class MutationConditionIfLengthEqualExtensions
    {
        public static IMutationSchema IfLengthEqual(this IMutationSchema mutationSchema, int length)
        {
            mutationSchema.AddCondition(new MutationConditionIfLengthEqual(length));
            return mutationSchema;
        }
    }
}
