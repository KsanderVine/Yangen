using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionStartsWithTests
    {
        [Theory]
        [InlineData("Somename", "Somena", false)]
        [InlineData("Somename", "So", false)]
        [InlineData("Somename", "___", true)]
        public void IsValidName_ReturnsTrue_IfValid(string name, string substring, bool isInverted)
        {
            var mutation = new MutationConditionStartsWith(substring, isInverted);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", "Somena", true)]
        [InlineData("Somename", "So", true)]
        [InlineData("Somename", "___", false)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, string substring, bool isInverted)
        {
            var mutation = new MutationConditionStartsWith(substring, isInverted);

            Assert.False(mutation.IsValidName(name));
        }
    }
}