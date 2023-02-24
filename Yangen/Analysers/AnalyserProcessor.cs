namespace Yangen
{
    public sealed class AnalyserProcessor : IAnalyserProcessor
    {
        public string? AnalyserTag { get; private set; }
        private IAnalyser? Analyser { get; set; }
        private IReport? Report { get; set; }

        public IAnalyserProcessor UsingAnalyser(IAnalyser analyser)
        {
            if (analyser is null)
                throw new ArgumentNullException(nameof(analyser));

            Analyser = analyser;
            return this;
        }

        public IAnalyserProcessor WithAnalyserTag(string analyserTag)
        {
            AnalyserTag = analyserTag;
            return this;
        }

        public IEnumerable<Name> ProcessNames(IEnumerable<Name> names)
        {
            if (Analyser != null)
            {
                Report = Analyser.GetReport(names);
            }

            return names;
        }

        public IReport? GetReport() => Report;
    }
}
