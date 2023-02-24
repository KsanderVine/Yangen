namespace Yangen
{
    public class MutationActionToLowerFirst : IMutationAction
    {
        public MutationActionToLowerFirst()
        {
        }

        public void ApplyForName(Name name)
        {
            if (name.Value.Length > 0)
            {
                string firstChar = name.Value[0].ToString().ToLower();
                name.Value.Remove(0, 1);
                name.Value.Insert(0, firstChar);
            }
        }
    }

    public static class MutationActionToLowerFirstExtensions
    {
        public static IMutationSchema ToLowerFirst(this IMutationSchema mutationSchema)
        {
            mutationSchema.AddAction(new MutationActionToUpperFirst());
            return mutationSchema;
        }
    }
}