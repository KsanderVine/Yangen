using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionToLowerTests
    {
        [Theory]
        [InlineData("Somename_A", "somename_a")]
        [InlineData("Somename_B", "somename_b")]
        [InlineData("Somename_C", "somename_c")]
        public void ApplyForName_ExpectedResult(string original, string expected)
        {
            var mutation = new MutationActionToLower();

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}