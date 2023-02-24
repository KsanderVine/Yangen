using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionContainsTests
    {
        [Theory]
        [InlineData("Somename", "Some", false)]
        [InlineData("Somename", "ome", false)]
        [InlineData("Somename", "___", true)]
        public void IsValidName_ReturnsTrue_IfValid_IfValid (string name, string substring, bool isInverted)
        {
            var mutation = new MutationConditionContains(substring, isInverted);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", "Some", true)]
        [InlineData("Somename", "ome", true)]
        [InlineData("Somename", "___", false)]
        public void IsValidName_ReturnsFalse_IfNotValid (string name, string substring, bool isInverted)
        {
            var mutation = new MutationConditionContains(substring, isInverted);

            Assert.False(mutation.IsValidName(name));
        }
    }
}