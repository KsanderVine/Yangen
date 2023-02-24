using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionReplaceWithAnyTests
    {
        [Theory]
        [InlineData("Somename", "Somen", "_ValueA_", "_ValB_", "_VC_")]
        [InlineData("Somename", "name", "_ValueA_", "_ValB_", "_VC_")]
        [InlineData("Somename", "Somename", "_ValueA_", "_ValB_", "_VC_")]
        public void ApplyForName_ExpectedResult(string original, string oldValue, params string[] values)
        {
            var mutation = new MutationActionReplaceWithAny(oldValue, values);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Contains(name.ToString(), CombineOriginalWithAllReplacements());

            IEnumerable<string> CombineOriginalWithAllReplacements()
            {
                return values.Select(value => original.Replace(oldValue, value));
            }
        }
    }
}