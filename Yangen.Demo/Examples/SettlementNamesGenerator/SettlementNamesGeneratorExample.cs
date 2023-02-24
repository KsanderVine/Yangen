using Yangen;

namespace Yangen.Demo.SettlementNamesGenerator
{
    public static class SettlementNamesGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static SettlementNamesGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(s => s
                    .Tag("name")
                    .AddGenerator<NameGenerator>(g => g
                        .WithSyllables(2, 3)
                        .WithDefaultSyllableSettings(s => s
                            .WithFirstVowelChance(0.1)
                            .WithConsonantsChance(0.6))
                        .WithLetterSet(l => l
                            .WithVowels("aeiouy")
                            .WithLeadingConsonants("lstnprmd")
                            .WithTailingConsonants("bcdfghklmnprstvhr")
                            .WithLeadingConsonantClusters("tr", "br", "th", "fl")
                            .WithTailingConsonantClusters("rd", "kr", "sk", "zh")))
                    .AddMutation(m => m
                        .WithChance(0.5)
                        .ForMatch(".+([lo]).+", (mut, r) => mut.Insert(r.Match.Groups[1].Index, r.Match.Groups[1].Value)))
                    .AddMutation(m => m
                        .WithChance(0.5)
                        .IfMatch("[^aeiouy]$")
                        .RemoveAt(int.MaxValue, -1)
                        .AppendWithAny("a", "e", "i", "o", "u", "y"))
                    .AddMutation(m => m
                        .IfMatch("[s]$")
                        .Append("e"))
                    .AddMutation(m => m
                        .ToUpperFirst()))
                .UsingSource(s => s
                    .Tag("type")
                    .AddNames("city", "village", "town", "station", "farm", "citadel", "tower"))
                .UsingTemplates(
                    "{name}'s {type}",
                    "{^type} of {name}");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
