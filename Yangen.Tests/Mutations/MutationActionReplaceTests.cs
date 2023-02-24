using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionReplaceTests
    {
        [Theory]
        [InlineData("Somename", "KindOfName", "Somen", "KindOfN")]
        [InlineData("Somename", "Sometitle", "name", "title")]
        [InlineData("Somename", "KindOfTitle", "Somename", "KindOfTitle")]
        public void ApplyForName_ExpectedResult(string original, string expected, string oldValue, string newValue)
        {
            var mutation = new MutationActionReplace(oldValue, newValue);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}