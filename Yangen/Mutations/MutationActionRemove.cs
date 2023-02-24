namespace Yangen
{
    public class MutationActionRemove : IMutationAction
    {
        private readonly string _value;

        public MutationActionRemove(string value)
        {
            _value = value;
        }

        public void ApplyForName(Name name)
        {
            name.Value.Replace(_value, "");
        }
    }

    public static class MutationActionRemoveExtensions
    {
        public static IMutationSchema Remove(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddAction(new MutationActionRemove(value));
            return mutationSchema;
        }
    }
}
