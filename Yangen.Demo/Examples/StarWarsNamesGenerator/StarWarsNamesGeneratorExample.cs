using Yangen;

namespace Yangen.Demo.StarWarsNamesGenerator
{
    public static class StarWarsNamesGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static StarWarsNamesGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(x => x
                    .Tag("name")
                    .AddGenerator<SyllableGenerator>(g => g
                        .WithDefaultLetterSet()
                        .WithDefaultSyllableSettings(s => s
                            .WithLeadingConsonantsChance(1.0)
                            .WithLeadingConsonantBeClusteredChance(0.01)
                            .WithVowelsChance(0.5)
                            .WithVowelBeClusteredChance(0.2)
                            .WithTailingConsonantsChance(0.0)))
                    .AddFilter(f => f
                        .WithMinLength(2)
                        .WhenNotMatchPattern("[bcdfghklmnprstvxhrw]{2}")))
                .UsingSource(s => s
                    .Tag("surname")
                    .AddGenerator<NameGenerator>(g => g
                        .WithSyllables(2, 3)
                        .WithDefaultLetterSet()
                        .WithDefaultSyllableSettings(c => c
                            .WithFirstVowelChance(0.4)
                            .WithLeadingConsonantsChance(1.0)
                            .WithVowelBeClusteredChance(0.05)
                            .WithTailingConsonantsChance(0.1)))
                    .AddMutationSwitch(
                        m1 => m1
                            .IfMatch("[aeiouy]$")
                            .AppendWithAny("ga", "da", "na", "ni", "bi"),
                        m2 => m2
                            .AppendWithAny("in", "er", "od", "on"))
                    .AddFilter(f => f
                        .WhenNotMatchPattern(@"(.)\1")))
                .UsingTemplates(
                    "{^name} {^surname}",
                    "{^name} {^name} {^surname}",
                    "{^name}{name} {^surname}",
                    "{^name}{name} {^name}{name} {^surname}",
                    "{^name}{name} {^name} {^surname}",
                    "{^name} {^name}{name} {^surname}",
                    "{^name}-{name} {^surname}",
                    "{^name}-{^name} {^surname}",
                    "{^name:0}-{^name:0} {^surname}",
                    "{^name:0} {^surname}{name:0}",
                    "{^name:0}{name:0} {^surname}",
                    "{^name:0}-{^name} {^surname}{name:0}");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
