namespace Yangen.Tokenizers
{
    internal class PlaceholderToken : IToken
    {
        public string Value => SourceTag;

        public string SourceTag { get; }
        public string ReferenceId { get; }
        public ModifierType Modifier { get; }

        public PlaceholderToken(string sourceTag, string referenceId, ModifierType modifier)
        {
            SourceTag = sourceTag;
            ReferenceId = referenceId;
            Modifier = modifier;
        }
    }
}
