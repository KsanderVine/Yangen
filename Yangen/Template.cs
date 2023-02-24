using System.Text;
using Yangen.Tokenizers;

namespace Yangen
{
    public sealed class Template
    {
        private readonly List<IToken> _tokens;

        public Template(string text)
        {
            var tokenizer = new PlaceholderTokenizer();
            _tokens = tokenizer.Tokenize(text).ToList();
        }

        public string Map(params string[] values)
        {
            if (GetTags().Count() != values.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(values),
                    "Count of template tags and provided values not equal!");
            }

            var valuesQueue = new Queue<string>(values);

            var resolvedReferences = ResolveReferences(valuesQueue);

            var resolvedQueue = new Queue<string>(resolvedReferences);

            return MapResolvedValues(resolvedQueue);
        }

        private string[] ResolveReferences(Queue<string> values)
        {
            List<string> resolvedValues = new();
            Dictionary<string, string> refereces = new();

            foreach (IToken token in _tokens)
            {
                if (token is PlaceholderToken placeholder)
                {
                    if (!string.IsNullOrWhiteSpace(placeholder.ReferenceId))
                    {
                        var referenceKey = $"{placeholder.SourceTag}:{placeholder.ReferenceId}";
                        if (refereces.TryGetValue(referenceKey, out string? referenceValue))
                        {
                            resolvedValues.Add(referenceValue);
                        }
                        else
                        {
                            string value = values.Dequeue();
                            refereces.Add(referenceKey, value);
                            resolvedValues.Add(value);
                        }
                    }
                    else
                    {
                        resolvedValues.Add(values.Dequeue());
                    }
                }
            }

            return resolvedValues.ToArray();
        }

        private string MapResolvedValues(Queue<string> values)
        {
            StringBuilder stringBuilder = new();

            foreach (IToken token in _tokens)
            {
                if (token is PlaceholderToken placeholder)
                {
                    StringBuilder value = new(values.Dequeue());

                    ApplyModifier(value, placeholder.Modifier);

                    stringBuilder.Append(value);
                }
                else
                if (token is SubstringToken substring)
                {
                    stringBuilder.Append(substring.Value);
                }
            }

            return stringBuilder.ToString();
        }

        private static StringBuilder ApplyModifier(StringBuilder value, ModifierType modifier)
        {
            return modifier switch
            {
                ModifierType.ToUpperFirst => ModifyFirstCharacter(value, true),
                ModifierType.ToLowerFirst => ModifyFirstCharacter(value, false),
                _ => value,
            };
        }

        private static StringBuilder ModifyFirstCharacter(StringBuilder value, bool toUpper)
        {
            if (value.Length > 0)
            {
                string firstChar = value[0].ToString();
                firstChar = toUpper ? firstChar.ToUpper() : firstChar.ToLower();
                return value.Remove(0, 1).Insert(0, firstChar);
            }
            else
            {
                return value;
            }
        }

        public IEnumerable<string> GetTags()
        {
            List<string> referenceIds = new();

            foreach (var token in _tokens)
            {
                if (token is PlaceholderToken placeholder)
                {
                    if (!string.IsNullOrWhiteSpace(placeholder.ReferenceId))
                    {
                        if (!referenceIds.Contains(placeholder.ReferenceId))
                        {
                            referenceIds.Add(placeholder.ReferenceId);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    yield return placeholder.Value;
                }
            }
        }

        public static implicit operator Template(string pattern) => new(pattern);
    }
}