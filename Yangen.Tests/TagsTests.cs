namespace Yangen.Tests
{
    public class TagsTests
    {
        [Fact]
        public void Add_ThrowsArgumentException_IfTagNullEmptyOrWriteSpace()
        {
            Tags tags = new();

            Assert.Throws<ArgumentException>(() => tags.Add("   "));
            Assert.Throws<ArgumentException>(() => tags.Add(null!));
            Assert.Throws<ArgumentException>(() => tags.Add(String.Empty));
        }

        [Fact]
        public void Remove_ThrowsArgumentException_IfTagNullEmptyOrWriteSpace()
        {
            Tags tags = new();

            Assert.Throws<ArgumentException>(() => tags.Remove("   "));
            Assert.Throws<ArgumentException>(() => tags.Remove(null!));
            Assert.Throws<ArgumentException>(() => tags.Remove(String.Empty));
        }
    }
}
