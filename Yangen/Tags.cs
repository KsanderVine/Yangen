using System.Collections;

namespace Yangen
{
    public class Tags : IEnumerable<string>
    {
        private readonly List<string> _values = new();

        public Tags Add(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                throw new ArgumentException($"Value of {nameof(tag)} can not be null, empty or write space");

            _values.Add(tag);
            return this;
        }

        public Tags Remove(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                throw new ArgumentException($"Value of {nameof(tag)} can not be null, empty or write space");

            _values.Remove(tag);
            return this;
        }

        public IEnumerator<string> GetEnumerator() => _values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();

        public override bool Equals(object? obj) => obj is not null && ReferenceEquals(this, obj);
        public override int GetHashCode() => base.GetHashCode();

        public static bool operator ==(Tags left, string right) => left.Contains(right);
        public static bool operator !=(Tags left, string right) => !left.Contains(right);

        public static Tags operator +(Tags left, string right) => left.Add(right);
        public static Tags operator -(Tags left, string right) => left.Remove(right);
    }
}