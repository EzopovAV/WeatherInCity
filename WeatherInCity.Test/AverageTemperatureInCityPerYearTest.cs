using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.IsTrue(Result.SequenceEqual(ItemsOutput), "Error array test.");
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

            Assert.IsTrue(Result.SequenceEqual(ItemsOutput), "Error list test.");
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

            Assert.IsTrue(Result.SequenceEqual(ItemsOutput), "Error different city test.");
        }

        [TestMethod]
        public void GetAverageTemperature_NullInput_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            Assert.ThrowsException<ArgumentNullException>(() => t.GetAverageTemperatureInCityPerYear(null));
        }

        [TestMethod]
        public void GetAverageTemperature_EmptyCityInput_Test()
        {
            List<Item> ItemsInput = new List<Item> {new Item{City = "", Year = 2000, Temperature = 7}};

            TemperatureInCity t = new TemperatureInCity();

            Assert.ThrowsException<ArgumentException>(() => t.GetAverageTemperatureInCityPerYear(ItemsInput));
        }

        [TestMethod]
        public void GetAverageTemperature_NotLetterCityInput_Test()
        {
            List<Item> ItemsInput = new List<Item> { new Item { City = "Moskva_", Year = 2000, Temperature = 7 } };

            TemperatureInCity t = new TemperatureInCity();

            Assert.ThrowsException<ArgumentException>(() => t.GetAverageTemperatureInCityPerYear(ItemsInput));
        }

        [TestMethod]
        public void GetAverageTemperature_ComplexCity_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            List<Item> ItemsInput = new List<Item> {
                                                    new Item{City = "Rostov na Donu", Year = 2000, Temperature = 7},
                                                    new Item{City = "Rostov na Donu", Year = 2000, Temperature = 13},
                                                    new Item{City = "Rostov na Donu", Year = 2000, Temperature = 25},
                                                    new Item{City = "Rostov na Donu", Year = 2001, Temperature = 11},
                                                    new Item{City = "Rostov na Donu", Year = 2001, Temperature = 17},
                                                    new Item{City = "Rostov na Donu", Year = 2001, Temperature = 23}
                                                   };

            List<Item> ItemsOutput = new List<Item> {
                                                     new Item{City = "Rostov na Donu", Year = 2000, Temperature = 15},
                                                     new Item{City = "Rostov na Donu", Year = 2001, Temperature = 17}
                                                    };

            var Result = t.GetAverageTemperatureInCityPerYear(ItemsInput);

            Assert.IsTrue(Result.SequenceEqual(ItemsOutput), "Error list test.");
        }

        [TestMethod]
        public void GetAverageTemperature_CheckRounding_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            List<Item> ItemsInput = new List<Item> {
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 1},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 2},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = 2}
                                                   };

            List<Item> ItemsOutput = new List<Item> {
                                                     new Item{City = "Saratov", Year = 2000, Temperature = 2}
                                                    };

            var Result = t.GetAverageTemperatureInCityPerYear(ItemsInput);

            Assert.IsTrue(Result.SequenceEqual(ItemsOutput), "Error list test.");
        }

        [TestMethod]
        public void GetAverageTemperature_NegativeTemperature_Test()
        {
            TemperatureInCity t = new TemperatureInCity();

            List<Item> ItemsInput = new List<Item> {
                                                    new Item{City = "Saratov", Year = 2000, Temperature = -10},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = -11},
                                                    new Item{City = "Saratov", Year = 2000, Temperature = -11}
                                                   };

            List<Item> ItemsOutput = new List<Item> {
                                                     new Item{City = "Saratov", Year = 2000, Temperature = -11}
                                                    };

            var Result = t.GetAverageTemperatureInCityPerYear(ItemsInput);

            Assert.IsTrue(Result.SequenceEqual(ItemsOutput), "Error list test.");
        }
    }
}
