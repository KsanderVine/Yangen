namespace Yangen.Tests
{
    public class TemplateTests
    {
        [Fact]
        public void Map_ThrowsArgumentOutOfRangeException_IfTagsCountNotEqualValues()
        {
            Template template = "{name} {surname} {other}";

            Assert.Throws<ArgumentOutOfRangeException>(() => template.Map("Name", "Surname"));
            Assert.Throws<ArgumentOutOfRangeException>(() => template.Map("Name", "Surname", "Other", "Another Other"));
        }

        [Fact]
        public void GetTags_ReturnsExpectedResult()
        {
            Template template = "{name} {surname} {other}";

            List<string> tags = new() { "name", "surname", "other" };

            Assert.Collection<string>(template.GetTags(),
                item => Assert.Equal("name", item),
                item => Assert.Equal("surname", item),
                item => Assert.Equal("other", item));
        }
    }
}
