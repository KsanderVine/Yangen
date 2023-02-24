namespace Yangen
{
    public class MutationActionRemoveAt : IMutationAction
    {
        private readonly int _index;
        private readonly int _length;

        public MutationActionRemoveAt(int index, int length)
        {
            _index = index;
            _length = length;
        }

        public void ApplyForName(Name name)
        {
            if (name.Value.Length > 0)
            {
                int index = _index;
                int length = _length;

                if (length < 0)
                {
                    length *= -1;
                    index -= length;

                    if (index < 0)
                    {
                        length += index;
                        index = 0;
                    }
                }

                if (index >= 0 && index < name.Value.Length)
                {
                    length = Math.Min(length, name.Value.Length - index);
                    name.Value.Remove(index, length);
                }
            }
        }
    }

    public static class MutationActionRemoveAtExtensions
    {
        public static IMutationSchema RemoveAt(this IMutationSchema mutationSchema, int index)
        {
            mutationSchema.AddAction(new MutationActionRemoveAt(index, 1));
            return mutationSchema;
        }

        public static IMutationSchema RemoveAt(this IMutationSchema mutationSchema, int index, int length)
        {
            mutationSchema.AddAction(new MutationActionRemoveAt(index, length));
            return mutationSchema;
        }
    }
}
