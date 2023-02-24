using Yangen.Extenstions;

namespace Yangen
{
    public class MutationActionAppendWithAny : IMutationAction
    {
        private readonly string[] _values;

        public MutationActionAppendWithAny(params string[] values)
        {
            _values = values;
        }

        public void ApplyForName(Name name)
        {
            name.Value.Append(_values.GetRandomItem());
        }
    }

    public static class MutationActionAppendWithAnyExtensions
    {
        public static IMutationSchema AppendWithAny(this IMutationSchema mutationSchema, params string[] values)
        {
            mutationSchema.AddAction(new MutationActionAppendWithAny(values));
            return mutationSchema;
        }
    }
}
