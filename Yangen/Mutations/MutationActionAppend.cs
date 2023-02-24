namespace Yangen
{
    public class MutationActionAppend : IMutationAction
    {
        private readonly string _value;

        public MutationActionAppend(string value)
        {
            _value = value;
        }

        public void ApplyForName(Name name)
        {
            name.Value.Append(_value);
        }
    }

    public static class MutationActionAppendExtensions
    {
        public static IMutationSchema Append(this IMutationSchema mutationSchema, string value)
        {
            mutationSchema.AddAction(new MutationActionAppend(value));
            return mutationSchema;
        }
    }
}
