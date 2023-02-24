using Yangen;

namespace Yangen.Demo.ElvenNamesGenerator
{
    public static class ElvenNamesGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static ElvenNamesGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(s => s
                    .Tag("part")
                    .AddGenerator<NameGenerator>(g => g
                        .WithLetterSet(l => l
                            .WithVowels("ae")
                            .WithConsonants("lvndr"))
                        .WithSyllables(1)
                        .WithDefaultSyllableSettings(c => c
                            .WithFirstVowelChance(0)
                            .WithLeadingConsonantsChance(1)
                            .WithTailingConsonantsChance(0.25))))
                .UsingSource(s => s
                    .Tag("name")
                    .AddGenerator<NameGenerator>(g => g
                        .WithLetterSet(l => l
                            .WithVowels("ae")
                            .WithConsonants("lvndr"))
                        .WithSyllables(2)
                        .WithDefaultSyllableSettings(c => c
                            .WithLeadingConsonantsChance(1)
                            .WithTailingConsonantsChance(0.25)))
                    .AddMutation(m => m
                        .AppendWithAny("der", "dar", "dur", "bor", "no", "in", "ol", "ar", "ing")))
                .UsingSource(s => s
                    .Tag("surname")
                    .AddGenerator<NameGenerator>(g => g
                        .WithLetterSet(l => l
                            .WithVowels("oiaue")
                            .WithVowelClusters("ae", "ai")
                            .WithLeadingConsonants("mbrsckntgl")
                            .WithTailingConsonants("rltk"))
                        .WithSyllables(1, 2)
                        .WithDefaultSyllableSettings(c => c
                            .WithFirstVowelChance(0.8)
                            .WithTailingConsonantsChance(0.1)))
                    .AddMutation(m => m
                        .AppendWithAny("ir", "ssa", "ae", "de", "el"))
                    .AddFilter(f => f
                        .WhenNotMatchPattern(@"(.)\1")))
                .UsingTemplates(
                    "{^part}'{^name} {^surname}",
                    "{^name} {!part} {^surname}",
                    "{^name} {^surname}");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
