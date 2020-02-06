using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherInCity.Test
{
    [TestClass]
    public class AverageTemperatureInCityPerYearTest
    {
        [TestMethod]
        public void GetAverageTemperature_InputArray_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            Item[] ItemsInput = {
                                    new Item{City = "Saratov", Year = 2000, Temperature = 10},
                                    new Item{City = "Saratov", Year = 2000, Temperature = 20},
                                    new Item{City = "Saratov", Year = 2000, Temperature = 30},
                                    new Item{City = "Saratov", Year = 2001, Temperature = 20},
                                    new Item{City = "Saratov", Year = 2001, Temperature = 40},
                                    new Item{City = "Saratov", Year = 2001, Temperature = 60}
                                };

            Item[] ItemsOutput = {
                                     new Item{City = "Saratov", Year = 2000, Temperature = 20},
                                     new Item{City = "Saratov", Year = 2001, Temperature = 40}
                                 };

            var Result = t.GetAverageTemperatureInCityPerYear(ItemsInput);

            Assert.IsTrue(CompareItems(ItemsOutput, Result), "Error array test.");
        }

        [TestMethod]
        public void GetAverageTemperature_InputList_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            List<Item> ItemsInput = new List<Item> {
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 7},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 13},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 25},
                                                    new Item{City = "Saratov", Year = 2001, Temperature = 11},
                                                    new Item{City = "Saratov", Year = 2001, Temperature = 17},
                                                    new Item{City = "Saratov", Year = 2001, Temperature = 23}
                                                   };

            List<Item> ItemsOutput = new List<Item> {
                                                     new Item{City = "Saratov", Year = 2000, Temperature = 15},
                                                     new Item{City = "Saratov", Year = 2001, Temperature = 17}
                                                    };

            var Result = t.GetAverageTemperatureInCityPerYear(ItemsInput);

            Assert.IsTrue(CompareItems(ItemsOutput, Result), "Error list test.");
        }

        [TestMethod]
        public void GetAverageTemperature_DifferentCity_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            List<Item> ItemsInput = new List<Item> {
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 7},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 13},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 25},
                                                    new Item{City = "Saratov", Year = 2001, Temperature = 11},
                                                    new Item{City = "Saratov", Year = 2001, Temperature = 17},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 23},
                                                    new Item{City = "Moskva", Year = 2000, Temperature = 30},
                                                    new Item{City = "Moskva", Year = 2000, Temperature = 20},
                                                    new Item{City = "Moskva", Year = 2001, Temperature = 20},
                                                    new Item{City = "Engels", Year = 2001, Temperature = 10},
                                                    new Item{City = "Engels", Year = 2001, Temperature = 20}
                                                   };

            List<Item> ItemsOutput = new List<Item> {
                                                     new Item{City = "Saratov", Year = 2000, Temperature = 17},
                                                     new Item{City = "Saratov", Year = 2001, Temperature = 14},
                                                     new Item{City = "Moskva", Year = 2000, Temperature = 25},
                                                     new Item{City = "Moskva", Year = 2001, Temperature = 20},
                                                     new Item{City = "Engels", Year = 2001, Temperature = 15}
                                                    };

            var Result = t.GetAverageTemperatureInCityPerYear(ItemsInput);

            Assert.IsTrue(CompareItems(ItemsOutput, Result), "Error different city test.");
        }



        bool CompareItems(IEnumerable<Item> items1, IEnumerable<Item> items2)
        {
            bool EqualItems = true;
            int count1 = 0, count2 = 0;
            foreach (var item in items1) count1++;
            foreach (var item in items2) count2++;
            if (count1 != count2) return false;

            var items2Enumerator = items2.GetEnumerator();
            foreach (var item in items1)
            {
                items2Enumerator.MoveNext();
                EqualItems = item.City == items2Enumerator.Current.City &&
                             item.Year == items2Enumerator.Current.Year &&
                             item.Temperature == items2Enumerator.Current.Temperature;
                if (!EqualItems) break;
            }

            return EqualItems;
        }
    }
}
