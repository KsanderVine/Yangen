namespace Yangen
{
    public interface IReportFormatter<TResult>
    {
        TResult FormatReport(IReport report);
    }
}
