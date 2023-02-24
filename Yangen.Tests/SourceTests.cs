using Yangen;

namespace Yangen.Tests
{
    public class SourceTests
    {
        [Fact]
        public void AddProcessor_ThrowsArgumentNullException_IfSourceProcessorIsNull()
        {
            var source = new Source();

            Assert.Throws<ArgumentNullException>(() => source.AddProcessor(null!));
        }

        [Fact]
        public void GetProcessors_ReturnsExpectedResult()
        {
            var processorA = new SourceProcessorStub();
            var processorB = new SourceProcessorStub();
            var processorC = new SourceProcessorStub();

            var source = new Source()
                .AddProcessor(processorA)
                .AddProcessor(processorB)
                .AddProcessor(processorC);

            Assert.Collection(source.GetProcessors(),
                item => Assert.Same(processorA, item),
                item => Assert.Same(processorB, item),
                item => Assert.Same(processorC, item));
        }

        [Fact]
        public void Tag_ThrowsArgumentException_IfTagNullEmptyOrWriteSpace()
        {
            var source = new Source();

            Assert.Throws<ArgumentException>(() => source.Tag(" ", null!, string.Empty));
            Assert.Throws<ArgumentException>(() => source.Tag(null!, string.Empty, " "));
            Assert.Throws<ArgumentException>(() => source.Tag(string.Empty, " ", null!));
        }

        [Fact]
        public void Tag_ThrowsArgumentNullException_IfTagsListIsNull()
        {
            var source = new Source();

            Assert.Throws<ArgumentNullException>(() => source.Tag(null!));
        }

        [Fact]
        public void GetRandomName_ReturnsNull_IfSourceNotConfigured()
        {
            var source = new Source();

            Assert.Null(source.GetRandomName());
        }

        [Fact]
        public void GetRandomName_ReturnsResult_IfSourceConfigured()
        {
            var source = new Source().AddNames("SomenameA", "SomenameB", "SomenameC");

            Assert.NotNull(source.GetRandomName());
        }

        [Fact]
        public void GetNames_ReturnsEmpty_IfSourceNotConfigured()
        {
            var source = new Source();

            Assert.Empty(source.GetNames());
        }

        [Fact]
        public void GetNames_ReturnsResult_IfSourceConfigured()
        {
            var source = new Source().AddNames("SomenameA", "SomenameB", "SomenameC");

            Assert.NotEmpty(source.GetNames());
        }
    }
}
