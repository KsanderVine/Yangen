using Yangen;

namespace Yangen.Tests.Filters
{
    public class FilterRuleStartsWithTests
    {
        [Theory]
        [InlineData("Somename", "Somena", false)]
        [InlineData("Somename", "So", false)]
        [InlineData("Somename", "___", true)]
        public void IsValidName_ReturnsTrue_IfValid(string name, string substring, bool isInverted)
        {
            var rule = new FilterRuleStartsWith(substring, isInverted);

            Assert.True(rule.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", "Somena", true)]
        [InlineData("Somename", "So", true)]
        [InlineData("Somename", "___", false)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, string substring, bool isInverted)
        {
            var rule = new FilterRuleStartsWith(substring, isInverted);

            Assert.False(rule.IsValidName(name));
        }
    }
}
