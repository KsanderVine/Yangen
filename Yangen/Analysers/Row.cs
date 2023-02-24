namespace Yangen
{
    public class Row : IRow
    {
        private readonly string[] _values;

        public Row(params object[] values)
        {
            _values = values.Select(v => v.ToString() ?? "<unknown-type>").ToArray();
        }

        public string[] GetValues() => _values;
    }
}
