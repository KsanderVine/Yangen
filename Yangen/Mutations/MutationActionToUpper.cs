namespace Yangen
{
    public class MutationActionToUpper : IMutationAction
    {
        public MutationActionToUpper()
        {
        }

        public void ApplyForName(Name name)
        {
            var upper = name.Value.ToString().ToUpper();
            name.Value.Clear();
            name.Value.Append(upper);
        }
    }

    public static class MutationActionToUpperExtensions
    {
        public static IMutationSchema ToUpper(this IMutationSchema mutationSchema)
        {
            mutationSchema.AddAction(new MutationActionToUpper());
            return mutationSchema;
        }
    }
}