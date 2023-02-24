namespace Yangen
{
    public class MutationActionToLower : IMutationAction
    {
        public MutationActionToLower()
        {
        }

        public void ApplyForName(Name name)
        {
            var upper = name.Value.ToString().ToLower();
            name.Value.Clear();
            name.Value.Append(upper);
        }
    }

    public static class MutationActionToLowerExtensions
    {
        public static IMutationSchema ToLower(this IMutationSchema mutationSchema)
        {
            mutationSchema.AddAction(new MutationActionToLower());
            return mutationSchema;
        }
    }
}