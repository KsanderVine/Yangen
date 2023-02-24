using Yangen;

namespace Yangen.Tests.Generators
{
    public class NameGeneratorTests
    {
        [Fact]
        public void WithLetterSet_ThrowsArgumentNullException_IfLetterSetIsNull()
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<ArgumentNullException>(() => nameGenerator.WithLetterSet((LetterSet)null!));
        }

        [Fact]
        public void WithLetterSet_Configured_ThrowsArgumentNullException_IfLetterSetIsNull()
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<NullReferenceException>(() => nameGenerator.WithLetterSet(x => null!));
        }

        [Fact]
        public void WithDefaultLetterSet_ThrowsArgumentNullException_IfLetterSetIsNull()
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<NullReferenceException>(() => nameGenerator.WithDefaultLetterSet(x => null!));
        }

        [Fact]
        public void WithSyllableSettings_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<ArgumentNullException>(() => nameGenerator.WithSyllableSettings((SyllableSettings)null!));
        }

        [Fact]
        public void WithSyllableSettings_Configured_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<NullReferenceException>(() => nameGenerator.WithSyllableSettings(x => null!));
        }

        [Fact]
        public void WithDefaultCSyllableSettings_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<NullReferenceException>(() => nameGenerator.WithDefaultSyllableSettings(x => null!));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void WithSyllableCount_ThrowsArgumentOutOfRangeException_IfLessOrEqualZero (int count)
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => nameGenerator.WithSyllables(count));
            Assert.Throws<ArgumentOutOfRangeException>(() => nameGenerator.WithSyllables(count - 1, count));
            Assert.Throws<ArgumentOutOfRangeException>(() => nameGenerator.WithSyllables((count - 1)..count));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 5)]
        [InlineData(14, -100)]
        public void WithSyllableCount_ThrowsArgumentOutOfRangeException_IfMaxLessThanMin(int min, int max)
        {
            var nameGenerator = new NameGenerator();

            Assert.Throws<ArgumentOutOfRangeException>(() => nameGenerator.WithSyllables(min, max));
            Assert.Throws<ArgumentOutOfRangeException>(() => nameGenerator.WithSyllables(min..max));
        }

        [Fact]
        public void Next_ReturnsEmptyString_IfGeneratorNotConfigured ()
        {
            var nameGenerator = new NameGenerator()
                .WithLetterSet(new LetterSet())
                .WithSyllableSettings(new SyllableSettings());

            Assert.Equal(string.Empty, nameGenerator.Next());
        }

        [Fact]
        public void Next_ReturnsNotEmptyString_IfGeneratorConfigured()
        {
            var nameGenerator = new NameGenerator()
                .WithDefaultLetterSet()
                .WithDefaultSyllableSettings();

            Assert.NotEqual(string.Empty, nameGenerator.Next());
        }

        [Fact]
        public void Next_ThrowsNullReferenceException_IfNoConfigurationProvided()
        {
            var nameGenerator = new NameGenerator()
                .WithDefaultLetterSet();

            Assert.Throws<NullReferenceException>(nameGenerator.Next);
        }

        [Fact]
        public void Next_ThrowsNullReferenceException_IfNoLetterSetProvided()
        {
            var nameGenerator = new NameGenerator()
                .WithDefaultSyllableSettings();

            Assert.Throws<NullReferenceException>(nameGenerator.Next);
        }
    }
}
