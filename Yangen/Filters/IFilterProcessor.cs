namespace Yangen
{
    public interface IFilterProcessor : ISourceProcessor
    {
        IFilterProcessor AddFilterRule(IFilterRule filterRule);
    }
}