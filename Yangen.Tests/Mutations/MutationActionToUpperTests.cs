using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionToUpperTests
    {
        [Theory]
        [InlineData("Somename_A", "SOMENAME_A")]
        [InlineData("Somename_B", "SOMENAME_B")]
        [InlineData("Somename_C", "SOMENAME_C")]
        public void ApplyForName_ExpectedResult(string original, string expected)
        {
            var mutation = new MutationActionToUpper();

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}