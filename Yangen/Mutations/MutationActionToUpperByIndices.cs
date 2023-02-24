namespace Yangen
{
    public class MutationActionToUpperByIndices : IMutationAction
    {
        private readonly int[] _indices;

        public MutationActionToUpperByIndices(params int[] indices)
        {
            _indices = indices;
        }

        public void ApplyForName(Name name)
        {
            foreach (var index in _indices)
            {
                if (index >= name.Value.Length)
                    continue;

                string upperChar = name.Value[index].ToString().ToUpper();
                name.Value.Remove(index, 1);
                name.Value.Insert(index, upperChar);
            }
        }
    }

    public static class MutationActionToUpperByIndicesExtensions
    {
        public static IMutationSchema ToUpperByIndecies(this IMutationSchema mutationSchema, params int[] indices)
        {
            mutationSchema.AddAction(new MutationActionToUpperByIndices(indices));
            return mutationSchema;
        }
    }
}