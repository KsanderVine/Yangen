namespace Yangen
{
    public interface IAnalyserProcessor : ISourceProcessor
    {
        string? AnalyserTag { get; }
        IAnalyserProcessor UsingAnalyser(IAnalyser analyser);
        IReport? GetReport();
    }
}
