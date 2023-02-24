using System.Text;

namespace Yangen
{
    public class Syllable
    {
        public Letter? LeadingConsonant { get; set; }
        public Letter? Vowel { get; set; }
        public Letter? TailingConsonant { get; set; }

        public Letter? GetFirstLetter()
        {
            if (LeadingConsonant is not null)
                return LeadingConsonant;

            if (Vowel is not null)
                return Vowel;

            return TailingConsonant;
        }

        public Letter? GetLastLetter()
        {
            if (TailingConsonant is not null)
                return TailingConsonant;

            if (Vowel is not null)
                return Vowel;

            return LeadingConsonant;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (LeadingConsonant is not null)
                sb.Append(LeadingConsonant);

            if (Vowel is not null)
                sb.Append(Vowel);

            if (TailingConsonant is not null)
                sb.Append(TailingConsonant);

            return sb.ToString();
        }
    }
}