using System;

namespace WeatherInCity
{
    public class Item : IEquatable<Item>
    {
        private  string _city;
        
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value.ToLower();
            }
        }
        public int Year { get; set; }
        public int Temperature { get; set; }

        public bool Equals(Item other)
        {
            if (Object.ReferenceEquals(this, other)) return true;
            if (Object.ReferenceEquals(other, null)) return false;
            return this._city == other._city && this.Year == other.Year && this.Temperature == other.Temperature;
        }

        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            return this.Equals(item);
        }

        public override int GetHashCode()
        {
            return this._city.GetHashCode()
                ^ this.Year.GetHashCode()
                ^ this.Temperature.GetHashCode();
        }
    }
}
