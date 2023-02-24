using Yangen;

namespace Yangen.Tests.Mutations
{
    public class SwitchMutationProcessorTests
    {
        [Fact]
        public void Ctor_ThrowsArgumentNullException_IfMutationSchemasIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SwitchMutationProcessor(null!));
        }

        [Fact]
        public void Ctor_ThrowsArgumentOutOfRangeException_IfMutationSchemasIsEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SwitchMutationProcessor(Array.Empty<IMutationSchema>()));
        }

        [Fact]
        public void ProcessNames_ReturnsExpectedResult_IfMutationProcessorNotConfigured()
        {
            var names = new List<Name>() { "SomenameA", "SomenameB", "SomenameC" };
            var processor = new SwitchMutationProcessor(new IMutationSchema[] { new MutationSchema() });

            Assert.Collection(processor.ProcessNames(names),
                x => x.Equals(names[0]),
                x => x.Equals(names[1]),
                x => x.Equals(names[2]));
        }
    }
}