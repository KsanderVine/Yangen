using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionRegexMatchTests
    {
        [Theory]
        [InlineData("Somename", false, "S.*e")]
        [InlineData("Somename", false, "^(S|s)ome")]
        public void IsValidName_ReturnsTrue_IfValid(string name, bool isInverted, string pattern)
        {
            var mutation = new MutationConditionRegexMatch(pattern, isInverted);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", true, "S.*e")]
        [InlineData("Somename", true, "^(S|s)ome")]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, bool isInverted, string pattern)
        {
            var mutation = new MutationConditionRegexMatch(pattern, isInverted);

            Assert.False(mutation.IsValidName(name));
        }
    }
}