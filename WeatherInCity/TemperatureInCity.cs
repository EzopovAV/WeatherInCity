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

            foreach (var item in items)
            {
                if (item.City == "" || item.City.Length < 2) throw new ArgumentException("City can't be empty and should consist of two or more letters.");
                
                if (!item.City.All(c => char.IsLetterOrDigit(c) || c == ' ')) throw new ArgumentException("City should consist only of letters, digits or space.");

                item.City = item.City.ToLower();
                item.City = char.ToUpper(item.City[0]) + item.City.Substring(1);
                if (item.City.Contains(" "))
                {
                    int indexSpace = item.City.IndexOf(" ");
                    item.City = item.City.Substring(0, indexSpace + 1) + char.ToUpper(item.City[indexSpace + 1]) + item.City.Substring(indexSpace + 2);
                }
            }

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
