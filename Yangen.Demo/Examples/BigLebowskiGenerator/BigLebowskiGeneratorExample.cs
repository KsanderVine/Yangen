using Yangen;

namespace Yangen.Demo.BigLebowskiGenerator
{
    public static class BigLebowskiGeneratorExample
    {
        private static readonly NamelessDesigner _designer;

        static BigLebowskiGeneratorExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(s => s
                    .Tag("name")
                    .AddGenerator<NameGenerator>(g => g
                        .WithSyllables(1,2)
                        .WithDefaultSyllableSettings()
                        .WithLetterSet(x => x
                            .WithVowels("aeiouy")
                            .WithVowelClusters("ae", "io", "ai", "ay", "ia", "ea", "ey", "ie", "ae", "oi", "au", "ou")
                            .WithConsonants("bcdfghklmnprstvhr")))
                    .AddFilter(f => f
                        .WhenNotMatchPattern("(^[aeiouy]{1,}$|[aeiouy]{3,}|[bcdfghklmnprstvxy]{3,})"))
                    .AddMutation(m => m
                        .IfNotMatch("[aeiouy]$")
                        .Append("o"))
                    .AddMutation(m => m
                        .Append("wski"))
                    .AddMutation(x => x
                        .ToUpperFirst()))
                .UsingTemplates(
                    "Where is the money, {name}?",
                    "I am not \"Mr.{name:1}\". You're Mr.{name:1}.");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}
