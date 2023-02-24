using Yangen.Extenstions;

namespace Yangen
{
    public class MutationActionReplaceWithAny : IMutationAction
    {
        private readonly string _oldValue;
        private readonly List<string> _values;

        public MutationActionReplaceWithAny(string oldValue, params string[] values)
        {
            _oldValue = oldValue;
            _values = new List<string>(values);
        }

        public void ApplyForName(Name name)
        {
            name.Value.Replace(_oldValue, _values.GetRandomItem());
        }
    }

    public static class MutationActionReplaceWithAnyExtensions
    {
        public static IMutationSchema ReplaceWithAny(this IMutationSchema mutationSchema, string oldValue, params string[] values)
        {
            mutationSchema.AddAction(new MutationActionReplaceWithAny(oldValue, values));
            return mutationSchema;
        }
    }
}
