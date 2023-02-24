namespace Yangen
{
    public interface ISourceProcessor
    {
        IEnumerable<Name> ProcessNames(IEnumerable<Name> names);
    }
}