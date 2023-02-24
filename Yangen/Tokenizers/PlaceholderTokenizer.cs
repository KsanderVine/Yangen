using System.Text.RegularExpressions;

namespace Yangen.Tokenizers
{
    internal class PlaceholderTokenizer : ITokenizer<IToken>
    {
        private readonly Regex _regex = new(@"{([\^!])?([A-za-z0-9]+)(?::([0-9]+))?}");
        private readonly RegexTokenizer _regexTokenizer;

        public PlaceholderTokenizer()
        {
            _regexTokenizer = new RegexTokenizer(@"{?[^{}]+}?");
        }

        public IEnumerable<IToken> Tokenize(string text)
        {
            var tokens = new List<IToken>();
            var stringTokens = _regexTokenizer.Tokenize(text);

            foreach (var selector in stringTokens.Select((token, i) => (i, token)))
            {
                Match match = _regex.Match(selector.token);
                if (match.Success)
                {
                    ModifierType modifier = DetermineModifier(match.Groups[1].Value);
                    string sourceTag = match.Groups[2].Value;
                    string referenceId = match.Groups[3].Value;

                    PlaceholderToken token = new(sourceTag, referenceId, modifier);
                    tokens.Add(token);
                }
                else
                {
                    tokens.Add(new SubstringToken(selector.token));
                }
            }

            return tokens;

            static ModifierType DetermineModifier(string value)
            {
                return value switch
                {
                    "!" => ModifierType.ToLowerFirst,
                    "^" => ModifierType.ToUpperFirst,
                    _ => ModifierType.None,
                };
            }
        }
    }
}
