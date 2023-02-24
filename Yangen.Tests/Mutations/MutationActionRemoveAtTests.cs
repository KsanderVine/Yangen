using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionRemoveAtTests
    {
        [Theory]
        [InlineData("Somename", "ame", 0, 5)]
        [InlineData("Somename", "me", 6, -6)]
        [InlineData("Somename", "", int.MaxValue, -int.MaxValue)]
        public void ApplyForName_ExpectedResult(string original, string expected, int index, int length)
        {
            var mutation = new MutationActionRemoveAt(index, length);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}