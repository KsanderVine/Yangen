using Yangen;

namespace Yangen.Demo.FantasyBeastsGenerator
{
    public static class FantasyBeastsGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static FantasyBeastsGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(s => s
                    .Tag("name1")
                    .AddGenerator<SyllableGenerator>(g => g
                        .WithDefaultLetterSet()
                        .WithDefaultSyllableSettings(s => s
                            .WithFirstVowelChance(0.0)
                            .WithLeadingConsonantsChance(1.0)
                            .WithTailingConsonantsChance(0.0)
                            .WithConsonantBeClusteredChance(0.05)
                            .WithVowelBeClusteredChance(0.05))))
                .UsingSource(s => s
                    .Tag("name2")
                    .AddGenerator<SyllableGenerator>(g => g
                        .WithDefaultSyllableSettings()
                        .WithDefaultLetterSet())
                    .AddMutation(m => m
                        .IfNotMatch("[aeiouy]$")
                        .AppendWithAny("a", "o", "e")))
                .UsingSource(s => s
                    .Tag("beast")
                    .AddNames(
                        "fox", "wolf", "bird", "cat", "rabbit", 
                        "mouse", "pig", "parrot", "hamster", "dog", 
                        "bull", "chicken", "cow", "sheep", "horse",
                        "lynx", "viper", "cobra", "lion", "bear",
                        "snake", "owl", "camel", "giraffe", "dragon"))
                .UsingTemplates(
                    "{^name2}{beast}",
                    "{^beast}{name2}",
                    "{^name1:0}-{^name1:0} {^beast}",
                    "{^name1}{name2} {^beast}",
                    "{^name1}{name2}-{^beast}",
                    "{^name1}{name2}{beast}",
                    "{^name1}{beast}{name2}",
                    "{^name1}{beast}");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
