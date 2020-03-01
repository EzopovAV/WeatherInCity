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
            if (items == null) throw new ArgumentNullException();

            var group = items.GroupBy(p => new { p.City, p.Year });

            List<Item> Result = new List<Item>();

            foreach (var item in group)
            {
                Result.Add(new Item
                {
                    City = item.Key.City,
                    Year = item.Key.Year,
                    Temperature = (int)Math.Round(item.Average(t => t.Temperature))
                });
            }

            return Result;  // return Type List<Item>

            //return items    // return Anonymous Type
            //    .GroupBy(p => new { p.City, p.Year })
            //    .Select(i => new Item
            //    {
            //        City = i.Key.City,
            //        Year = i.Key.Year,
            //        Temperature = (int)Math.Round(i.Average(t => t.Temperature))
            //    });
        }
    }
}
