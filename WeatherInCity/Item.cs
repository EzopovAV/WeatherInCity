using System;

namespace WeatherInCity
{
    public class Item : IEquatable<Item>
    {
        public string City { get; set; }
        public int Year { get; set; }
        public int Temperature { get; set; }

        public bool Equals(Item other)
        {
            if (Object.ReferenceEquals(this, other)) return true;
            if (Object.ReferenceEquals(other, null)) return false;
            return this.City == other.City && this.Year == other.Year && this.Temperature == other.Temperature;
        }
    }
}
