using System.Text;

namespace Yangen
{
    internal sealed class SyllableForDebugging : Syllable
    {
        public override string ToString()
        {
            var sb = new StringBuilder();

            if (LeadingConsonant is not null)
                sb.Append(LeadingConsonant);
            else
                sb.Append('^');

            if (Vowel is not null)
                sb.Append(Vowel);
            else
                sb.Append('?');

            if (TailingConsonant is not null)
                sb.Append(TailingConsonant);
            else
                sb.Append('$');

            sb.Append('_');
            return sb.ToString();
        }
    }
}