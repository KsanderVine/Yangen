using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yangen.Tests
{
    public class NamelessDesignerTests
    {
        [Fact]
        public void Next_ThrowsNullReferenceException_IfNoSourceProvided()
        {
            var designer = new NamelessDesigner();

            Assert.Throws<NullReferenceException>(designer.Next);
        }

        [Fact]
        public void NextWithTag_ThrowsArgumentException_IfTagIsNullOrWriteSpace()
        {
            var designer = new NamelessDesigner();

            Assert.Throws<ArgumentException>(() => designer.NextWithTag("   "));
            Assert.Throws<ArgumentException>(() => designer.NextWithTag(null!));
            Assert.Throws<ArgumentException>(() => designer.NextWithTag(String.Empty));
        }

        [Fact]
        public void NextWithTag_ThrowsNullReferenceException_IfCouldNotFindSourceWithTag()
        {
            var designer = new NamelessDesigner()
                .UsingSource(x => x.Tag("SomeTag"));

            Assert.Throws<NullReferenceException>(() => designer.NextWithTag("some_tag"));
        }

        [Fact]
        public void NextWithTemplate_ThrowsArgumentNullException_IfTemplateIsNull()
        {
            var designer = new NamelessDesigner();

            Assert.Throws<ArgumentNullException>(() => designer.NextWithTemplate(null!));
        }

        [Fact]
        public void UsingSource_ThrowsArgumentNullException_IfSourceIsNull()
        {
            var designer = new NamelessDesigner();

            Assert.Throws<ArgumentNullException>(() => designer.UsingSource((ISource)null!));
        }

        [Fact]
        public void UsingSource_ThrowsNullReferenceException_IfSourceIsNull()
        {
            var designer = new NamelessDesigner();

            Assert.Throws<NullReferenceException>(() => designer.UsingSource(x => null!));
        }
    }
}
