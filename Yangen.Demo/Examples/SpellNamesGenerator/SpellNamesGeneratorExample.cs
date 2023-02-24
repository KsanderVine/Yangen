using Yangen;

namespace Yangen.Demo.SpellNamesGenerator
{
    public static class SpellNamesGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static SpellNamesGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(x => x
                    .AddGenerator<NameGenerator>(g => g
                        .WithLetterSet(l => l
                            .Frequency(30, f => f
                                .WithConsonants("brtcmntd")
                                .WithVowels("ao"))
                            .Frequency(10, f => f
                                .WithConsonants("lpsv")
                                .WithVowels("iue"))
                            .Frequency(1, f => f
                                .WithTailingConsonants("x")
                                .WithConsonants("wgfkh"))
                            .WithVowelClusters("ae", "io", "ai", "ay", "ia", "ea", "ey", "ie", "ae", "oi", "au", "ou")
                            .WithConsonantClusters("br", "bl", "sc", "tr", "pl", "st")
                            .WithLeadingConsonantClusters("gl", "gr", "pr", "cr", "th")
                            .WithTailingConsonantClusters("nc", "nd", "nt", "ng", "rd", "rt", "rg", "vr", "vd", "xp", "mp"))
                        .WithDefaultSyllableSettings(s => s
                            .WithFirstVowelChance(0.5)
                            .WithVowelBeClusteredChance(0.01)
                            .WithLeadingConsonantBeClusteredChance(0.1)
                            .WithTailingConsonantBeClusteredChance(0.01)
                            .WithTailingConsonantsChance(0.8))
                        .WithSyllables(1, 3))
                    .AddFilter(f => f
                        .WithMinLength(3))
                    .AddNames("eng", "org", "expec", "evanes", "wing", "aloha", "obliv", "imp", "repar", "cruc", "riddik", "avad")
                    .AddMutationSwitch(
                        m => m
                            .IfEndsWith("c")
                            .AppendWithAny("uro", "to", "io"),
                        m => m
                            .IfEndsWith("t")
                            .AppendWithAny("ate", "is", "ia", "o", "or", "os", "us"),
                        m => m
                            .IfEndsWith("d")
                            .AppendWithAny("o", "io", "ia"),
                        m => m
                            .IfEndsWith("l")
                            .AppendWithAny("a", "ae", "os", "us", "um"),
                        m => m
                            .IfEndsWith("n")
                            .AppendWithAny("a", "ae", "os", "us", "um"),
                        m => m
                            .IfEndsWith("r")
                            .AppendWithAny("ase", "ae", "ate", "dre", "us", "um"),
                        m => m
                            .IfMatch("[ei]$")
                            .Append("o"),
                        m => m
                            .IfNotMatch("[aeiouy]$")
                            .AppendWithAny("eo", "io", "ios"),
                        m => m
                            .RemoveAt(int.MaxValue,-1)
                            .AppendWithAny("es", "os"))
                    .AddFilter(f => f
                        .WhenNotContains("dt")
                        .WhenNotContains("td")
                        .WhenNotMatchPattern(
                            "^[aeiouy]{1,}$",
                            "[aeiouy]{3,}",
                            "([bcdfghklmnprstvxy]){3,}"))
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
