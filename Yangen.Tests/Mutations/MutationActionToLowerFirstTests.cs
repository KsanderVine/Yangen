using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionToLowerFirstTests
    {
        [Theory]
        [InlineData("SOMENAME", "sOMENAME")]
        [InlineData("OTHERNAME", "oTHERNAME")]
        [InlineData("KINDOFNAME", "kINDOFNAME")]
        public void ApplyForName_ExpectedResult(string original, string expected)
        {
            var mutation = new MutationActionToLowerFirst();

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Equal(expected, name.ToString());
        }
    }
}