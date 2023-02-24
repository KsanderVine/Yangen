using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yangen;

namespace Yangen.Tests.Processors
{
    public class NamesEnumProcessorTests
    {
        [Fact]
        public void ProcessNames_ReturnsExpectedResult ()
        {
            var names = new List<string>() { "SomenameA", "SomenameB", "SomenameC" };
            var processor = new NamesEnumProcessor(names.ToArray());

            Assert.Collection(processor.ProcessNames(new List<Name>()),
                x => x.Equals(names[0]),
                x => x.Equals(names[1]),
                x => x.Equals(names[2]));
        }
    }
}
