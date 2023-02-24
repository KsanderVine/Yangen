using Yangen;

namespace Yangen.Tests
{
    public class SourceProcessorStub : ISourceProcessor
        {
            public IEnumerable<Name> ProcessNames(IEnumerable<Name> names) => names;
        }
}
