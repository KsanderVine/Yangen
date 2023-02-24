namespace Yangen
{
    public interface ISource
    {
        Tags Tags { get; set; }

        ISource Tag(params string[] tags);

        ISource AddProcessor(ISourceProcessor sourceProcessor);
        IEnumerable<ISourceProcessor> GetProcessors();

        ISource AsCompilable();
        ISource AsNotCompilable();

        IEnumerable<Name> GetNames();
        Name? GetRandomName();
    }
}