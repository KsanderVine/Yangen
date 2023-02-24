using System.Text;

namespace Yangen
{
    public class ConsoleTableReportFormatter : IReportFormatter<string>
    {
        private const int CellPadding = 1;

        public string FormatReport(IReport report)
        {
            List<int> columnsWidth = CalculateColumnsWidth(report);
            int totalWidth = columnsWidth.Sum();

            string line = string.Empty.PadRight(totalWidth, '-');
            string cellPadding = string.Empty.PadRight(CellPadding, ' ');

            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(line);

            foreach (var (index, column) in report.GetColumns().Select((x, i) => (i, x)))
            {
                int columnWidth = columnsWidth[index];

                string formattedValue = column
                    .Insert(0, "|")
                    .Insert(1, cellPadding)
                    .PadRight(columnWidth - 1) + "|";

                stringBuilder.Append(formattedValue);
            }

            stringBuilder.AppendLine();
            stringBuilder.AppendLine(line);

            foreach (var row in report.GetRows())
            {
                foreach (var (index, value) in row.GetValues().Select((x, i) => (i, x)))
                {
                    int columnWidth = columnsWidth[index];

                    string formattedValue = value
                        .Insert(0, "|")
                        .Insert(1, " ")
                        .PadRight(columnWidth - 1) + "|";

                    stringBuilder.Append(formattedValue);
                }
                stringBuilder.AppendLine();
            }

            stringBuilder.AppendLine(line);

            return stringBuilder.ToString();
        }

        private static List<int> CalculateColumnsWidth(IReport report)
        {
            List<int> columnsWidth = new();
            foreach (var column in report.GetColumns())
            {
                var cellWidth = column.Length + (CellPadding * 2) + 2;
                columnsWidth.Add(cellWidth);
            }

            foreach (var row in report.GetRows())
            {
                foreach (var (index, value) in row.GetValues().Select((x, i) => (i, x)))
                {
                    var cellWidth = value.Length + (CellPadding * 2) + 2;
                    columnsWidth[index] = Math.Max(cellWidth, columnsWidth[index]);
                }
            }
            return columnsWidth;
        }
    }
}
