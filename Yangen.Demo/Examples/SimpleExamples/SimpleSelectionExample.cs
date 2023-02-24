using Yangen;

namespace Yangen.Demo.SimpleExamples
{
    public static class SimpleSelectionExample
    {
        private static readonly NamelessDesigner _designer;
        private static readonly IReportFormatter<string> _formatter;

        static SimpleSelectionExample()
        {
            _formatter = new ConsoleTableReportFormatter();

            _designer = new NamelessDesigner()
                .UsingSource(x => x
                    .Tag("name")
                    .AddNames("Harry", "Hermione", "Ron", "Hagrid"))
                .UsingSource(x => x
                    .Tag("surname")
                    .AddNames("Potter", "Granger", "Weasley", "Rubeus"))
                .UsingTemplates("{name} {surname}");
        }

        public static IEnumerable<string> GetSamples(int count)
        {
            for (int i = 0; i < count; i++)
                yield return _designer.Next();
        }
    }
}