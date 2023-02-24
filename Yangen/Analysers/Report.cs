namespace Yangen
{
    public class Report : IReport
    {
        private readonly string[] _columns;
        private readonly List<IRow> _rows;

        public Report(params string[] columns)
        {
            _columns = columns;
            _rows = new List<IRow>();
        }

        public void AddRow(object[] values)
        {
            if (_columns.Length != values.Length)
                throw new ArgumentOutOfRangeException(nameof(values));

            _rows.Add(new Row(values));
        }

        public IEnumerable<string> GetColumns() => _columns;

        public IEnumerable<IRow> GetRows() => _rows;
    }
}
