﻿namespace HouseNumbers.BusinessLogic.Models
{
    public class HouseNumberDetails : IComparable<HouseNumberDetails>
    {
        public int Number { get; set; }

        public string? Suffix { get; set; }

        /// <summary>
        /// Implement IComparable<T> to allow sorting of custom objects
        /// </summary>
        /// <param name="other">The object your comparing to</param>
        /// <returns>1 if this object is Greater, 0 if both objects are Equals, -1 if the other object is Greater</returns>
        public int CompareTo(HouseNumberDetails? other)
        {
            if (other == null)
                return 1;

            if (Number == other.Number)
            {
                if (Suffix == other.Suffix)
                    return 0;

                if (Suffix?.FirstOrDefault() > other.Suffix?.FirstOrDefault())
                    return 1;

                return -1;
            }

            if (Number > other.Number)
                return 1;

            return -1;
        }

        public override string ToString()
        {
            return $"{Number}{Suffix}";
        }
    }
}