using Yangen;

namespace Yangen.Tests.Generators
{
    public class SyllableGeneratorTests
    {
        [Fact]
        public void WithLetterSet_ThrowsArgumentNullException_IfLetterSetIsNull()
        {
            var syllableGenerator = new SyllableGenerator();

            Assert.Throws<ArgumentNullException>(() => syllableGenerator.WithLetterSet((LetterSet)null!));
        }

        [Fact]
        public void WithLetterSet_Configured_ThrowsArgumentNullException_IfLetterSetIsNull()
        {
            var syllableGenerator = new SyllableGenerator();

            Assert.Throws<NullReferenceException>(() => syllableGenerator.WithLetterSet(x => null!));
        }

        [Fact]
        public void WithDefaultLetterSet_ThrowsArgumentNullException_IfLetterSetIsNull()
        {
            var syllableGenerator = new SyllableGenerator();

            Assert.Throws<NullReferenceException>(() => syllableGenerator.WithDefaultLetterSet(x => null!));
        }

        [Fact]
        public void WithSyllableSettings_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            var syllableGenerator = new SyllableGenerator();

            Assert.Throws<ArgumentNullException>(() => syllableGenerator.WithSyllableSettings((SyllableSettings)null!));
        }

        [Fact]
        public void WithSyllableSettings_Configured_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            var syllableGenerator = new SyllableGenerator();

            Assert.Throws<NullReferenceException>(() => syllableGenerator.WithSyllableSettings(x => null!));
        }

        [Fact]
        public void WithDefaultSyllableSettings_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            var syllableGenerator = new SyllableGenerator();

            Assert.Throws<NullReferenceException>(() => syllableGenerator.WithDefaultSyllableSettings(x => null!));
        }

        [Fact]
        public void Next_ReturnsEmptyString_IfGeneratorNotConfigured()
        {
            var syllableGenerator = new SyllableGenerator()
                .WithLetterSet(new LetterSet())
                .WithSyllableSettings(new SyllableSettings());

            Assert.Equal(string.Empty, syllableGenerator.Next());
        }

        [Fact]
        public void Next_ReturnsNotEmptyString_IfGeneratorConfigured()
        {
            var syllableGenerator = new SyllableGenerator()
                .WithDefaultLetterSet()
                .WithDefaultSyllableSettings();

            Assert.NotEqual(string.Empty, syllableGenerator.Next());
        }

        [Fact]
        public void Next_ThrowsNullReferenceException_IfNoConfigurationProvided()
        {
            var syllableGenerator = new SyllableGenerator()
                .WithDefaultLetterSet();

            Assert.Throws<NullReferenceException>(syllableGenerator.Next);
        }

        [Fact]
        public void Next_ThrowsNullReferenceException_IfNoLetterSetProvided()
        {
            var syllableGenerator = new SyllableGenerator()
                .WithDefaultSyllableSettings();

            Assert.Throws<NullReferenceException>(syllableGenerator.Next);
        }
    }
}