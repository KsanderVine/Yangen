using System.Text.RegularExpressions;

namespace Yangen.Tokenizers
{
    internal class RegexTokenizer : ITokenizer<string>
    {
        private readonly Regex _regex;

        public RegexTokenizer(string pattern)
        {
            _regex = new(@pattern);
        }

        public IEnumerable<string> Tokenize(string text)
        {
            return _regex.Matches(text).Select(m => m.Value);
        }
    }
}
