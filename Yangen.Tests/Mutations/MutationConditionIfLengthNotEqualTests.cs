using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionIfLengthNotEqualTests
    {
        [Theory]
        [InlineData("Somename", 9)]
        [InlineData("Othername", 10)]
        [InlineData("KindOfName", 11)]
        public void IsValidName_ReturnsTrue_IfValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthNotEqual(length);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", 8)]
        [InlineData("Othername", 9)]
        [InlineData("KindOfName", 10)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthNotEqual(length);

            Assert.False(mutation.IsValidName(name));
        }
    }
}