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
                if (item.City == "") throw new ArgumentException("City can't be empty.");
                
                if (!item.City.All(c => char.IsLetterOrDigit(c) || c == ' ')) throw new ArgumentException("City should consist only of letters, digits or space.");
            }

            //var group = items.GroupBy(p => new { p.City, p.Year });

            //List<Item> Result = new List<Item>();

            //foreach (var item in group)
            //{
            //    Result.Add(new Item
            //    {
            //        City = item.Key.City,
            //        Year = item.Key.Year,
            //        Temperature = (int)Math.Round(item.Average(t => t.Temperature))
            //    });
            //}

            //return Result;


            return items
                .GroupBy(p => new { p.City, p.Year })
                .Select(i => new Item
                {
                    City = i.Key.City,
                    Year = i.Key.Year,
                    Temperature = (int)Math.Round(i.Average(t => t.Temperature))
                });

        }
    }
}
