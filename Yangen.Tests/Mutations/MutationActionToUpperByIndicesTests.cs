using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionToUpperByIndicesTests
    {
        [Theory]
        [InlineData("somename", "someNAME", 4, 5, 6, 7)]
        [InlineData("somename", "SOmEnAmE", 0, 1, 3, 5, 7)]
        [InlineData("somename", "sOMENAME", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10)]
        public void ApplyForName_ExpectedResult(string original, string expected, params int[] indices)
        {
            var mutation = new MutationActionToUpperByIndices(indices);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}