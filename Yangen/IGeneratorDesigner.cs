namespace Yangen
{
    public interface IGeneratorDesigner<TDesigner>
    {
        TDesigner UsingSource(ISource source);
        TDesigner UsingSource(Func<ISource, ISource> configure);
        string Next();
    }
}