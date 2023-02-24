using Yangen;

namespace Yangen.Tests.Filters
{
    public class FilterRuleContainsTests
    {
        [Theory]
        [InlineData("Somename", "Some", false)]
        [InlineData("Somename", "ome", false)]
        [InlineData("Somename", "___", true)]
        public void IsValidName_ReturnsTrue_IfValid (string name, string substring, bool isInverted)
        {
            var rule = new FilterRuleContains(substring, isInverted);

            Assert.True(rule.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", "Some", true)]
        [InlineData("Somename", "ome", true)]
        [InlineData("Somename", "___", false)]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, string substring, bool isInverted)
        {
            var rule = new FilterRuleContains(substring, isInverted);

            Assert.False(rule.IsValidName(name));
        }
    }
}
