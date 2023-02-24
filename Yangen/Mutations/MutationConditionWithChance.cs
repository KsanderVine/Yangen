namespace Yangen
{
    public class MutationConditionWithChance : IMutationCondition
    {
        private readonly double _chance;

        public MutationConditionWithChance(double chance)
        {
            if (chance < 0 || chance > 1)
                throw new ArgumentException($"Value of {nameof(chance)} must be within range [0 ~ 1]");

            _chance = chance;
        }

        public bool IsValidName(Name name)
        {
            var rand = new Random().NextDouble();
            return rand <= _chance;
        }
    }

    public static class MutationConditionWithChanceExtensions
    {
        public static IMutationSchema WithChance(this IMutationSchema mutationSchema, double chance)
        {
            mutationSchema.AddCondition(new MutationConditionWithChance(chance));
            return mutationSchema;
        }
    }
}
