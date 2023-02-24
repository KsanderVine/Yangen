using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionInsertTests
    {
        [Theory]
        [InlineData("SomenameA", "ValueA_SomenameA", -4, "ValueA_")]
        [InlineData("SomenameB", "SomenameB_ValueB", int.MaxValue, "_ValueB")]
        [InlineData("SomenameC", "Some_ValueC_nameC", 4, "_ValueC_")]
        public void ApplyForName_ExpectedResult(string original, string expected, int index, string insert)
        {
            var mutation = new MutationActionInsert(index, insert);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}