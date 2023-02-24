namespace Yangen.Tokenizers
{
    internal interface ITokenizer<TResult>
    {
        IEnumerable<TResult> Tokenize(string text);
    }
}
