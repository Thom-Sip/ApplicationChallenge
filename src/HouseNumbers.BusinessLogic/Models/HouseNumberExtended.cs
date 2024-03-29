namespace HouseNumbers.BusinessLogic.Models
{
    public class HouseNumberExtended : IComparable<HouseNumberExtended>
    {
        public required int Number { get; init; }

        public string Suffix { get; init; } = string.Empty;

        public int? SuffixExtra { get; init; }

        /// <summary>
        /// Implement IComparable<T> to allow sorting of custom objects
        /// </summary>
        /// <param name="other">The object your comparing to</param>
        /// <returns>1 if this object is Greater, 0 if both objects are Equals, -1 if the other object is Greater</returns>
        public int CompareTo(HouseNumberExtended? other)
        {
            if (other == null)
                return 1;

            if (Number == other.Number)
            {
                if(Suffix == other.Suffix)
                {
                    return (SuffixExtra ?? 0).CompareTo(other.SuffixExtra ?? 0);
                }

                return Suffix.CompareTo(other.Suffix);
            }   

            return Number.CompareTo(other.Number);
        }

        public override string ToString()
        {
            return SuffixExtra != null
                ? $"{Number}{Suffix}-{SuffixExtra}"
                : $"{Number}{Suffix}";
        }
    }
}
