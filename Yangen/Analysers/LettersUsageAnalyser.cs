namespace Yangen
{
    public sealed class LettersUsageAnalyser : IAnalyser
    {
        public IReport? GetReport(IEnumerable<Name> names)
        {
            Dictionary<char, int> lettersCounters = new();
            foreach (var name in names)
            {
                foreach (var chunk in name.Value.GetChunks())
                {
                    foreach (var letter in chunk.Span)
                    {
                        if (lettersCounters.ContainsKey(letter))
                        {
                            lettersCounters[letter]++;
                        }
                        else
                        {
                            lettersCounters.Add(letter, 1);
                        }
                    }
                }
            }

            IReport report = new Report("Letter", "Usage count");

            foreach (var letter in lettersCounters.Keys)
            {
                report.AddRow(letter, lettersCounters[letter]);
            }

            return report;
        }
    }
}
