using Yangen;

namespace Yangen.Demo.RobotNamesGenerator
{
    public static class RobotNamesGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static RobotNamesGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(s => s
                    .Tag("code")
                    .AddGenerator<SyllableGenerator>(g => g
                        .WithDefaultLetterSet()
                        .WithDefaultSyllableSettings(c => c
                            .WithFirstVowelChance(0)
                            .WithConsonantsChance(1)
                            .WithConsonantBeClusteredChance(0)))
                    .AddFilter(f => f
                        .WithLengthRange(3, 3))
                    .AddMutation(m => m
                        .ToUpper()))
                .UsingSource(s => s
                    .Tag("number")
                    .AddGenerator<NumberGenerator>(g => g
                        .WithRange(1, 10)
                        .WithTotalLength(2)
                        .WithLeftPadding()))
                .UsingSource(s => s
                    .Tag("roman_number")
                    .AddGenerator<RomanNumberGenerator>(g => g
                        .WithRange(1, 10)))
                .UsingSource(s => s
                    .Tag("number_long")
                    .AddGenerator<NumberGenerator>(g => g
                        .WithRange(1, 999)
                        .WithTotalLength(5)
                        .WithLeftPadding()
                        .WithRightPadding()))
                .UsingTemplates(
                    "{code}{number}",
                    "{code}/{number}-{number}",
                    "{number_long}:{code}",
                    "{code}{number} Mark {roman_number}",
                    "{code}{number}-{number}-{number_long}-{code}");
        }
        
        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
