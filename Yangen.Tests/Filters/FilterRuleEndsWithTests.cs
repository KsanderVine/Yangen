using Yangen;

namespace Yangen.Tests.Filters
{
    public class FilterRuleEndsWithTests
    {
        [Theory]
        [InlineData("Somename", "omename", false)]
        [InlineData("Somename", "ame", false)]
        [InlineData("Somename", "___", true)]
        public void IsValidName_ReturnsTrue_IfValid(string name, string substring, bool isInverted)
        {
            var rule = new FilterRuleEndsWith(substring, isInverted);

            Assert.True(rule.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", "omename", true)]
        [InlineData("Somename", "ame", true)]
        [InlineData("Somename", "___", false)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, string substring, bool isInverted)
        {
            var rule = new FilterRuleEndsWith(substring, isInverted);

            Assert.False(rule.IsValidName(name));
        }
    }
}
