using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionEndsWithTests
    {
        [Theory]
        [InlineData("Somename", "omename", false)]
        [InlineData("Somename", "ame", false)]
        [InlineData("Somename", "___", true)]
        public void IsValidName_ReturnsTrue_IfValid(string name, string substring, bool isInverted)
        {
            var mutation = new MutationConditionEndsWith(substring, isInverted);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", "omename", true)]
        [InlineData("Somename", "ame", true)]
        [InlineData("Somename", "___", false)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, string substring, bool isInverted)
        {
            var mutation = new MutationConditionEndsWith(substring, isInverted);

            Assert.False(mutation.IsValidName(name));
        }
    }
}