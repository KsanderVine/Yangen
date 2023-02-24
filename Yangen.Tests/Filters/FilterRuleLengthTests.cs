using Yangen;

namespace Yangen.Tests.Filters
{
    public class FilterRuleLengthTests
    {
        [Theory]
        [InlineData("Somename", 0, 8)]
        [InlineData("Somename", 0, 10)]
        [InlineData("Somename", 5, 50)]
        public void IsValidName_ReturnsTrue_IfValid(string name, int minLength, int maxLength)
        {
            var rule = new FilterRuleLength(minLength, maxLength);

            Assert.True(rule.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", 10, 18)]
        [InlineData("Somename", 10, 110)]
        [InlineData("Somename", 15, 150)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, int minLength, int maxLength)
        {
            var rule = new FilterRuleLength(minLength, maxLength);

            Assert.False(rule.IsValidName(name));
        }
    }
}
