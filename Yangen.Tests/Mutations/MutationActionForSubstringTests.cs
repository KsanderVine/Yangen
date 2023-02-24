using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionForSubstringTests
    {
        [Fact]
        public void Constructor_ThrowsArgumentNullException_IfConfigurationIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new MutationActionForSubstring("Substing", null!));
        }

        [Fact]
        public void Constructor_ThrowsArgumentException_IfSubstringValueNullEmptyOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new MutationActionForSubstring(null!, (mut, res) => { }));
            Assert.Throws<ArgumentException>(() => new MutationActionForSubstring(String.Empty, (mut, res) => { }));
            Assert.Throws<ArgumentException>(() => new MutationActionForSubstring(" ", (mut, res) => { }));
        }

        [Theory]
        [InlineData("Somename", "Somename", "o")]
        [InlineData("Simona", "Simona", "im")]
        [InlineData("Takero", "Takero", "o")]
        [InlineData("Legolas", "Legolas", "as")]
        public void ApplyForName_ExpectedOriginal_IfNotConfigured(string original, string expected, string substring)
        {
            var mutation = new MutationActionForSubstring(substring, (mut, res) => { });

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }

        [Theory]
        [InlineData("Somename", "Somename", "Somename_")]
        [InlineData("Simona", "Simona", "Simona_")]
        [InlineData("Takero", "Takero", "Takero_")]
        [InlineData("Legolas", "Legolas", "Legolas_")]
        public void ApplyForName_ExpectedOriginal_IfSubstringNotFound(string original, string expected, string pattern)
        {
            var mutation = new MutationActionForSubstring(pattern, (mut, res) => mut.Append("_somestring_"));

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }

        [Theory]
        [InlineData("Somename", "Teromename", "S", "Ter")]
        [InlineData("Simona", "Gimona", "S", "G")]
        [InlineData("Takero", "Takede", "ro", "de")]
        [InlineData("Legolas", "Tranduil", "Legolas", "Tranduil")]
        public void ApplyForName_ExpectedReplacement_IfSubstringFound(string original, string expected, string substring, string replacement)
        {
            var mutation = new MutationActionForSubstring(substring, (mut, res) => mut.Replace(substring, replacement));

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.EndsWith(expected, name.ToString());
        }
    }
}