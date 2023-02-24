using Yangen;

namespace Yangen.Tests.Mutations
{
    public class SingleMutationProcessorTests
    {
        [Fact]
        public void Ctor_ThrowsArgumentNullException_IfMutationSchemaIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SingleMutationProcessor(null!));
        }

        [Fact]
        public void ProcessNames_ReturnsExpectedResult_IfMutationProcessorNotConfigured()
        {
            var names = new List<Name>() { "SomenameA", "SomenameB", "SomenameC" };
            var processor = new SingleMutationProcessor(new MutationSchema());

            Assert.Collection(processor.ProcessNames(names), 
                x => x.Equals(names[0]),
                x => x.Equals(names[1]),
                x => x.Equals(names[2]));
        }
    }
}