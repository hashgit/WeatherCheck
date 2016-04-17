using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherCheck.Services;

namespace WeatherCheck.Tests
{
    [TestClass]
    public class City
    {
        [TestMethod]
        public async Task CanGetListOfCities()
        {
            var service = new CityService();
            var cities = await service.GetCities("Australia");

            Assert.IsNotNull(cities);
            Assert.AreEqual(66, cities.Count());
        }

        [TestMethod]
        public async Task CitiesNotFound()
        {
            var service = new CityService();
            var cities = await service.GetCities("NonExistingCountry");

            Assert.IsNotNull(cities);
            Assert.AreEqual(0, cities.Count());
        }
    }
}
