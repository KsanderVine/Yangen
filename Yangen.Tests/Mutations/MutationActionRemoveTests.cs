using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionRemoveTests
    {
        [Theory]
        [InlineData("Somename", "name", "Some")]
        [InlineData("Somename", "Some", "name")]
        [InlineData("Somename", "Somme", "ena")]
        public void ApplyForName_ExpectedResult(string original, string expected, string value)
        {
            var mutation = new MutationActionRemove(value);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}