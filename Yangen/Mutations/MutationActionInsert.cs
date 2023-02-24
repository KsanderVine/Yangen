namespace Yangen
{
    public class MutationActionInsert : IMutationAction
    {
        private readonly int _index;
        private readonly string _value;

        public MutationActionInsert(int index, string value)
        {
            _index = index;
            _value = value;
        }

        public void ApplyForName(Name name)
        {
            if (name.Length > 0)
            {
                int index = Math.Clamp(_index, 0, name.Length);
                name.Value.Insert(index, _value);
            }
        }
    }

    public static class MutationActionInsertExtensions
    {
        public static IMutationSchema Insert(this IMutationSchema mutationSchema, int index, string value)
        {
            mutationSchema.AddAction(new MutationActionInsert(index, value));
            return mutationSchema;
        }
    }
}
