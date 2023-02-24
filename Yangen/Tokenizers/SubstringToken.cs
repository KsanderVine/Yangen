namespace Yangen.Tokenizers
{
    internal class SubstringToken : IToken
    {
        public string Value { get; }

        public SubstringToken(string value)
        {
            Value = value;
        }
    }
}
