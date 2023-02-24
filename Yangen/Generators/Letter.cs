namespace Yangen
{
    public sealed class Letter
    {
        public string Value { get; set; }
        public int Frequency { get; set; }
        public LetterType LetterType { get; set; }

        public Letter(string value, LetterType letterType, int frequency = 1)
        {
            Value = value;
            LetterType = letterType;
            Frequency = frequency;
        }

        public bool HasFlag(LetterType flag)
        {
            return LetterType.HasFlag(flag);
        }

        public override string ToString()
        {
            return Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}