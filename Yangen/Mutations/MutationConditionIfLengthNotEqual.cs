namespace Yangen
{
    public class MutationConditionIfLengthNotEqual : IMutationCondition
    {
        private readonly int _length;

        public MutationConditionIfLengthNotEqual(int length)
        {
            _length = length;
        }

        public bool IsValidName(Name name)
        {
            return name.Value.Length != _length;
        }
    }

    public static class MutationConditionIfLengthNotEqualExtensions
    {
        public static IMutationSchema IfLengthNotEqual(this IMutationSchema mutationSchema, int length)
        {
            mutationSchema.AddCondition(new MutationConditionIfLengthNotEqual(length));
            return mutationSchema;
        }
    }
}
