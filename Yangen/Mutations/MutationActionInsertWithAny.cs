using Yangen.Extenstions;

namespace Yangen
{
    public class MutationActionInsertWithAny : IMutationAction
    {
        private readonly int _index;
        private readonly string[] _values;

        public MutationActionInsertWithAny(int index, params string[] values)
        {
            if (!values.Any())
                throw new ArgumentNullException(nameof(values), "No values provided");

            _index = index;
            _values = values;
        }

        public void ApplyForName(Name name)
        {
            if (name.Length > 0)
            {
                int index = Math.Clamp(_index, 0, name.Length);
                name.Value.Insert(index, _values.GetRandomItem());
            }
        }
    }

    public static class MutationActionInsertWithAnyExtensions
    {
        public static IMutationSchema InsertWithAny(this IMutationSchema mutationSchema, int index, params string[] values)
        {
            mutationSchema.AddAction(new MutationActionInsertWithAny(index, values));
            return mutationSchema;
        }
    }
}
