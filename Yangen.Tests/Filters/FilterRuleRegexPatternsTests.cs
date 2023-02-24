using Yangen;

namespace Yangen.Tests.Filters
{
    public class FilterRuleRegexPatternsTests
    {
        [Theory]
        [InlineData("Somename", true, "S.*e")]
        [InlineData("Somename", true, "ame$", "^(S|s)ome")]
        public void IsValidName_ReturnsTrue_IfValid(string name, bool allowMatched, params string[] patterns)
        {
            var rule = new FilterRuleRegexPatterns(allowMatched, patterns);

            Assert.True(rule.IsValidName(name));
        }

        [Theory]
        [InlineData("Somename", false, "S.*e")]
        [InlineData("Somename", false, "ame$", "^(S|s)ome")]
        public void IsValidName_ReturnsFalse_IfNotValid(string name, bool allowMatched, params string[] patterns)
        {
            var rule = new FilterRuleRegexPatterns(allowMatched, patterns);

            Assert.False(rule.IsValidName(name));
        }
    }
}
