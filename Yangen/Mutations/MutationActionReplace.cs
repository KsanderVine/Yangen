namespace Yangen
{
    public class MutationActionReplace : IMutationAction
    {
        private readonly string _oldValue;
        private readonly string _newValue;

        public MutationActionReplace(string oldValue, string newValue)
        {
            _oldValue = oldValue;
            _newValue = newValue;
        }

        public void ApplyForName(Name name)
        {
            name.Value.Replace(_oldValue, _newValue);
        }
    }

    public static class MutationActionReplaceExtensions
    {
        public static IMutationSchema Replace(this IMutationSchema mutationSchema, string oldValue, string newValue)
        {
            mutationSchema.AddAction(new MutationActionReplace(oldValue, newValue));
            return mutationSchema;
        }
    }
}
