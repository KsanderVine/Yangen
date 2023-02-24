using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionAppendTests
    {
        [Theory]
        [InlineData("Somename", "Some", "name")]
        [InlineData("Simon", "Simo", "n")]
        [InlineData("Takero", "Take", "ro")]
        [InlineData("Legolas", "Lego", "las")]
        public void ApplyForName_ExpectedResult(string expected, string original, string ending)
        {
            var mutation = new MutationActionAppend(ending);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}