namespace Yangen
{
    public class MutationActionToLowerByIndices : IMutationAction
    {
        private readonly int[] _indices;

        public MutationActionToLowerByIndices(params int[] indices)
        {
            _indices = indices;
        }

        public void ApplyForName(Name name)
        {
            foreach (var index in _indices)
            {
                if (index >= name.Value.Length)
                    continue;

                string lowerChar = name.Value[index].ToString().ToLower();
                name.Value.Remove(index, 1);
                name.Value.Insert(index, lowerChar);
            }
        }
    }

    public static class MutationActionToLowerByIndicesExtensions
    {
        public static IMutationSchema ToLowerByIndecies(this IMutationSchema mutationSchema, params int[] indices)
        {
            mutationSchema.AddAction(new MutationActionToLowerByIndices(indices));
            return mutationSchema;
        }
    }
}