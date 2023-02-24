using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationActionAppendWithAnyTests
    {
        [Theory]
        [InlineData("Some", "name")]
        [InlineData("Simo", "n", "na")]
        [InlineData("Take", "ro", "de", "ba")]
        [InlineData("Lego", "las", "pas", "tas")]
        public void ApplyForName_ExpectedResult(string original, params string[] endings)
        {
            var mutation = new MutationActionAppendWithAny(endings);

            Name name = new(original);
            mutation.ApplyForName(name);

            Assert.Contains(name.ToString(), CombineOriginalWithAllEndings());

            IEnumerable<string> CombineOriginalWithAllEndings()
            {
                return endings.Select(ending => $"{original}{ending}");
            }
        }
    }
}