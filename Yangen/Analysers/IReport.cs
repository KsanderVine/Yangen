namespace Yangen
{
    public interface IReport
    {
        IEnumerable<string> GetColumns();
        IEnumerable<IRow> GetRows();

        void AddRow(params object[] values);
    }
}
