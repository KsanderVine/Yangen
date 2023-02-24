using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionIfLengthEqualTests
    {
        [Theory]
        [InlineData("Somename", 8)]
        [InlineData("Othername", 9)]
        [InlineData("KindOfName", 10)]
        public void IsValidName_ReturnsTrue_IfValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthEqual(length);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", 1)]
        [InlineData("Othername", 1)]
        [InlineData("KindOfName", 1)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthEqual(length);

            Assert.False(mutation.IsValidName(name));
        }
    }
}