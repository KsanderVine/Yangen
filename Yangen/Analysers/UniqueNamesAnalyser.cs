namespace Yangen
{
    public sealed class UniqueNamesAnalyser : IAnalyser
    {
        public IReport? GetReport(IEnumerable<Name> names)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int failedCount = 0;

            foreach (var name in names)
            {
                if (!uniqueNames.Add(name.ToString()))
                    failedCount++;
            }

            IReport report = new Report("Unique", "Repeats");
            report.AddRow(uniqueNames.Count, failedCount);
            return report;
        }
    }
}
