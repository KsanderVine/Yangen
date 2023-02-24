using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionForMatchesTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MutationActionForMatches("MatchMe", null!));
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_IfPatternNullEmptyOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new MutationActionForMatches(null!, (mut, res) => { }));
            Assert.Throws<ArgumentException>(() => new MutationActionForMatches(String.Empty, (mut, res) => { }));
            Assert.Throws<ArgumentException>(() => new MutationActionForMatches(" ", (mut, res) => { }));
        }

        [Theory]
        [InlineData("Somename", "Somename", "Somename")]
        [InlineData("Simona", "Simona", "Simona")]
        [InlineData("Takero", "Takero", "Takero")]
        [InlineData("Legolas", "Legolas", "Legolas")]
        public void ApplyForName_ExpectedOriginal_IfNotConfigured(string original, string expected, string pattern)
        {
            var mutation = new MutationActionForMatches(pattern, (mut, res) => { });

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }

        [Theory]
        [InlineData("Somename", "Somename", "Somename_")]
        [InlineData("Simona", "Simona", "Simona_")]
        [InlineData("Takero", "Takero", "Takero_")]
        [InlineData("Legolas", "Legolas", "Legolas_")]
        public void ApplyForName_ExpectedOriginal_IfPatternNotMatches(string original, string expected, string pattern)
        {
            var mutation = new MutationActionForMatches(pattern, (mut, res) => mut.Append("_somestring_"));

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }

        [Theory]
        [InlineData("Somename", "Somename_endingA", "Somename", "_endingA")]
        [InlineData("Simona", "Simona_endingB", "Sim.*", "_endingB")]
        [InlineData("Takero", "Takero_endingC", "^(T|t)ak", "_endingC")]
        [InlineData("Legolas", "Legolas_endingD", "las$", "_endingD")]
        public void ApplyForName_ExpectedEnding_IfPatternMatches(string original, string expected, string pattern, string ending)
        {
            var mutation = new MutationActionForMatches(pattern, (mut, res) => mut.Append(ending));

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.EndsWith(expected, name.ToString());
        }
    }
}