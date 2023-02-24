using System.Text;

namespace Yangen
{
    public sealed class Name
    {
        public StringBuilder Value { get; set; }

        public int Length => Value.Length;

        public Name(string value) => Value = new StringBuilder(value);
        public Name(StringBuilder value) => Value = new StringBuilder(value.ToString());

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is string nameString)
            {
                return this == nameString;
            }

            if (obj is StringBuilder sb)
            {
                return this == sb;
            }

            if (obj is Name name)
            {
                return this == name;
            }

            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode() => Value.ToString().GetHashCode();
        public override string ToString() => Value.ToString();

        public static bool operator ==(Name left, Name right) => left.Value == right.Value;
        public static bool operator !=(Name left, Name right) => left.Value != right.Value;

        public static bool operator ==(string left, Name right) => left == right.Value.ToString();
        public static bool operator !=(string left, Name right) => left != right.Value.ToString();

        public static bool operator ==(Name left, string right) => right == left.Value.ToString();
        public static bool operator !=(Name left, string right) => right != left.Value.ToString();

        public static bool operator ==(StringBuilder left, Name right) => left == right.Value;
        public static bool operator !=(StringBuilder left, Name right) => left != right.Value;

        public static bool operator ==(Name left, StringBuilder right) => right == left.Value;
        public static bool operator !=(Name left, StringBuilder right) => right != left.Value;

        public static implicit operator Name(string name) => new(name);
    }
}