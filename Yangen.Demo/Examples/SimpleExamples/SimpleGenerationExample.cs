using Yangen;

namespace Yangen.Demo.SimpleExamples
{
    public static class SimpleGenerationExample
    {
        private static readonly NamelessDesigner _designer;

        static SimpleGenerationExample()
        {
            _designer = new NamelessDesigner()
                .UsingSource(x => x
                    .Tag("name")
                    .AddGenerator<NameGenerator>(g => g.WithDefault())
                    .AddMutation(m => m.ToUpperFirst()))
                .UsingTemplates("{name}");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}