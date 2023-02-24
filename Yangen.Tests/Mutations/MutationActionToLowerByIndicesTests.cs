using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionToLowerByIndicesTests
    {
        [Theory]
        [InlineData("SOMENAME", "someNAME", 0, 1, 2, 3)]
        [InlineData("SOMENAME", "SOmEnAmE", 2, 4, 6, 8, 10, 12, 14)]
        [InlineData("SOMENAME", "sOMENAME", 0)]
        public void ApplyForName_ExpectedResult(string original, string expected, params int[] indices)
        {
            var mutation = new MutationActionToLowerByIndices(indices);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}