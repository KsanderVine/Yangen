using System.Text;

namespace Yangen.Extenstions
{
    internal static class StringExtensions
    {
        public static int[] AllIndexesOf(this string str, string value, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value is not specified.");

            var indexes = new List<int>();
            int length = value.Length;
            int position = 0;

            do
            {
                position = str.IndexOf(value, position, comparisonType);
                if (position != -1)
                {
                    indexes.Add(position);
                    position += length;
                }

            } while (position != -1);


            return indexes.ToArray();
        }

        public static string Repeat(this string value, int count)
        {
            StringBuilder stringBuilder = new();

            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(value);
            }

            return stringBuilder.ToString();
        }
    }
}
