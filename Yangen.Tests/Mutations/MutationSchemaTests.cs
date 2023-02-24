using Yangen;

namespace Yangen.Tests.Mutations
{
    public class MutationSchemaTests
    {
        [Fact]
        public void AddAction_ThrowsArgumentNullException_IfActionIsNull()
        {
            var mutationSchema = new MutationSchema();

            Assert.Throws<ArgumentNullException>(() => mutationSchema.AddAction(null!));
        }

        [Fact]
        public void AddCondition_ThrowsArgumentNullException_IfConditionIsNull()
        {
            var mutationSchema = new MutationSchema();

            Assert.Throws<ArgumentNullException>(() => mutationSchema.AddCondition(null!));

        }

        [Fact]
        public void IsValidName_ThrowsArgumentNullException_IfNameIsNull()
        {
            var mutationSchema = new MutationSchema();

            Assert.Throws<ArgumentNullException>(() => mutationSchema.IsValidName(null!));

        }

        [Fact]
        public void ApplyForName_ThrowsArgumentNullException_IfNameIsNull()
        {
            var mutationSchema = new MutationSchema();

            Assert.Throws<ArgumentNullException>(() => mutationSchema.ApplyForName(null!));
        }
    }
}