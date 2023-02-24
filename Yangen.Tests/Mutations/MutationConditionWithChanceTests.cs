using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationConditionWithChanceTests
    {
        [Fact]
        public void IsValidName_ReturnsTrue_IfValid_IfChanceEqualOne()
        {
            var mutation = new MutationConditionWithChance(1.0);

            Assert.True(mutation.IsValidName("Somename"));
        }

        [Fact]
        public void IsValidName_ReturnsFalse_IfNotValid_IfChanceEqualZero()
        {
            var mutation = new MutationConditionWithChance(0.0);

            Assert.False(mutation.IsValidName("Somename"));
        }
    }
}