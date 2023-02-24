using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionToUpperFirstTests
    {
        [Theory]
        [InlineData("somename", "Somename")]
        [InlineData("othername", "Othername")]
        [InlineData("kindofname", "Kindofname")]
        public void ApplyForName_ExpectedResult(string original, string expected)
        {
            var mutation = new MutationActionToUpperFirst();

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}