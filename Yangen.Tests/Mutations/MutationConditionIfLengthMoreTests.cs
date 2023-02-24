using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionIfLengthMoreTests
    {
        [Theory]
        [InlineData("Somename", 1)]
        [InlineData("Othername", -10)]
        [InlineData("KindOfName", int.MinValue)]
        public void IsValidName_ReturnsTrue_IfValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthMore(length);

            Assert.True(mutation.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", 50)]
        [InlineData("Othername", 40)]
        [InlineData("KindOfName", int.MaxValue)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, int length)
        {
            var mutation = new MutationConditionIfLengthMore(length);

            Assert.False(mutation.IsValidName(name));
        }
    }
}