using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherInCity
{
    public class TemperatureInCity
    {
        public IEnumerable<Item> GetAverageTemperatureInCityPerYear(IEnumerable<Item> items)
        {
            var group = items.GroupBy(p => new { p.City, p.Year });

            List<Item> Result = new List<Item>();

            foreach (var item in group)
            {
                Result.Add(new Item
                {
                    City = item.Key.City,
                    Year = item.Key.Year,
                    Temperature = (int)item.Average(t => t.Temperature)
                });
            }

            return Result;
        }
    }
}
