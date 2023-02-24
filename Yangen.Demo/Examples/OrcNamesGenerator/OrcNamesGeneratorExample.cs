using Yangen;

namespace Yangen.Demo.OrcNamesGenerator
{
    public static class OrcNamesGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static OrcNamesGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(s => s
                    .AddGenerator<NameGenerator>(g => g
                        .WithLetterSet(l => l
                            .WithVowels("aiuoe")
                            .WithConsonants("nzlgrm")
                            .WithConsonantClusters("sh", "hr", "ks", "kr" ,"nt", "nd", "rt", "rd", "rr"))
                        .WithSyllables(2)
                        .WithDefaultSyllableSettings(c => c
                            .WithVowelsChance(0.95)
                            .WithConsonantsChance(0.95)
                            .WithLeadingConsonantBeClusteredChance(0.1)
                            .WithTailingConsonantBeClusteredChance(0.5)))
                    .AddMutation(m => m
                        .IfMatch("[aeiouy]$")
                        .AppendWithAny("grym", "grim", "drim", "dur", "zog", "urk"))
                    .AddMutation(m => m
                        .ToUpperFirst()));
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
