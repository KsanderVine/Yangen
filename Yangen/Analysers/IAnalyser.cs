namespace Yangen
{
    public interface IAnalyser
    {
        IReport? GetReport(IEnumerable<Name> names);
    }
}
