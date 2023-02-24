using Yangen;

namespace Yangen.Tests.Generators
{
    public class GeneratorProcessorTests
    {
        [Fact]
        public void UsingGenerator_ThrowsArgumentNullException_IfGeneratorIsNull()
        {
            List<Name> names = new() { "SomenameA", "SomenameB", "SomenameC" };
            var generatorProcessor = new GeneratorProcessor();

            Assert.Throws<ArgumentNullException>(() => generatorProcessor.UsingGenerator(null!));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WithPoolSize_ThrowsArgumentOutOfRangeException_IfLessOrEqualZero(int count)
        {
            var generatorProcessor = new GeneratorProcessor();

            Assert.Throws<ArgumentOutOfRangeException>(() => generatorProcessor.WithPoolSize(count));
        }

        [Fact]
        public void ProcessNames_ThrowsNullReferenceException_IfGeneratorNotSpecified()
        {
            List<Name> names = new() { "SomenameA", "SomenameB", "SomenameC" };
            var generatorProcessor = new GeneratorProcessor();

            Assert.Throws<NullReferenceException>(() => generatorProcessor.ProcessNames(names));
        }
    }
}
