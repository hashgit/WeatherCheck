using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherCheck.Services;

namespace WeatherCheck.Tests
{
    [TestClass]
    public class WeatherServiceTests
    {
        [TestMethod]
        public async Task CanGetWeatherOfAhmadabad()
        {
            var service = new WeatherService();
            var weather = await service.GetWeather("India", "Ahmadabad");

            Assert.IsNotNull(weather);
        }

        [TestMethod]
        public async Task WeatherNotFound()
        {
            var service = new WeatherService();
            var weather = await service.GetWeather("India", "InvalidCity");

            Assert.IsNull(weather);
        }
    }
}
