using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionInsertWithAnyTests
    {
        [Theory]
        [InlineData("SomenameA", -4, "ValueA_", "ValB_", "VC_")]
        [InlineData("SomenameB", int.MaxValue, "_ValueA", "_ValB", "_VC")]
        [InlineData("SomenameC", 4, "_ValueA_", "_ValB_", "_VC_")]
        public void ApplyForName_ExpectedResult(string original, int index, params string[] values)
        {
            var mutation = new MutationActionInsertWithAny(index, values);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Contains(name.ToString(), CombineOriginalWithAllInserts());

            IEnumerable<string> CombineOriginalWithAllInserts()
            {
                int indexClamped = Math.Clamp(index, 0, original.Length);
                return values.Select(value => original.Insert(indexClamped, value));
            }
        }
    }
}