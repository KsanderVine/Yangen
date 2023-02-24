namespace Yangen
{
    public static class AnalyserExtensions
    {
        public static IReport? GetAnalyserReport(this NamelessDesigner yangenDesigner, string analyserTag)
        {
            foreach (var source in yangenDesigner.GetSources())
            {
                foreach (var processor in source.GetProcessors())
                {
                    if (processor is IAnalyserProcessor analyserProcessor)
                    {
                        if (analyserTag.Equals(analyserProcessor.AnalyserTag))
                        {
                            return analyserProcessor.GetReport();
                        }
                    }
                }
            }

            return null;
        }

        public static ISource AnalyseLettersUsage(this ISource source, string analyserTag)
        {
            IAnalyserProcessor analyserProcessor = new AnalyserProcessor()
                .WithAnalyserTag(analyserTag)
                .UsingAnalyser(new LettersUsageAnalyser());

            source.AddProcessor(analyserProcessor);
            return source;
        }

        public static ISource AnalyseUniqueNames(this ISource source, string analyserTag)
        {
            IAnalyserProcessor analyserProcessor = new AnalyserProcessor()
                .WithAnalyserTag(analyserTag)
                .UsingAnalyser(new UniqueNamesAnalyser());

            source.AddProcessor(analyserProcessor);
            return source;
        }
    }
}
