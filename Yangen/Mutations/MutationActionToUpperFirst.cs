namespace Yangen
{
    public class MutationActionToUpperFirst : IMutationAction
    {
        public MutationActionToUpperFirst()
        {
        }

        public void ApplyForName(Name name)
        {
            if (name.Value.Length > 0)
            {
                string firstChar = name.Value[0].ToString().ToUpper();
                name.Value.Remove(0, 1);
                name.Value.Insert(0, firstChar);
            }
        }
    }

    public static class MutationActionToUpperFirstExtensions
    {
        public static IMutationSchema ToUpperFirst(this IMutationSchema mutationSchema)
        {
            mutationSchema.AddAction(new MutationActionToUpperFirst());
            return mutationSchema;
        }
    }
}