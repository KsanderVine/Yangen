using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionIfLengthLessOrEqualTests
    {
        [Theory]
        [InlineData("Somename", 8)]
        [InlineData("Othername", 9)]
        [InlineData("KindOfName", 10)]
        public void IsValidName_ReturnsTrue_IfValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthLessOrEqual(length);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", 5)]
        [InlineData("Othername", 5)]
        [InlineData("KindOfName", 5)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthLessOrEqual(length);

            Assert.False(mutation.IsValidName(name));
        }
    }
}