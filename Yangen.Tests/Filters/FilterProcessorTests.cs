using Yangen;

namespace Yangen.Tests.Filters
{
    public class FilterProcessorTests
    {
        [Fact]
        public void AddFilterRule_ThrowsArgumentNullException_IfFilterRuleIsNull()
        {
            var filterProcessor = new FilterProcessor();

            Assert.Throws<ArgumentNullException>(() => filterProcessor.AddFilterRule(null!));
        }

        [Fact]
        public void ProcessNames_ReturnsExpectedResult_IfFilterNotConfigured()
        {
            List<Name> names = new() { "SomenameA", "SomenameB", "SomenameC" };
            var filterProcessor = new FilterProcessor();

            Assert.Collection(filterProcessor.ProcessNames(names), 
                item => Assert.Same(names[0], item),
                item => Assert.Same(names[1], item),
                item => Assert.Same(names[2], item));
        }
    }
}
