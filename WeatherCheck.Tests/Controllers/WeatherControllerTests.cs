using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherCheck.Controllers.Api;
using WeatherCheck.Services;
using WeatherCheck.Services.Dto;

namespace WeatherCheck.Tests.Controllers
{
    [TestClass]
    public class WeatherControllerTests
    {
        [TestMethod]
        public async Task CanGetWeather()
        {
            var value = new WeatherDto
            {
                RelativeHumidity = "20%"
            };

            var weatherService = new Mock<IWeatherService>();
            weatherService.Setup(s => s.GetWeather("Australia", "Sydney"))
                .ReturnsAsync(value);

            var controller = new WeatherController(weatherService.Object);
            var result = await controller.Get("Australia", "Sydney");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<WeatherDto>));

            var resultObject = result as OkNegotiatedContentResult<WeatherDto>;
            Assert.AreEqual(value, resultObject.Content);
        }

        [TestMethod]
        public async Task CityNotFound()
        {

            var weatherService = new Mock<IWeatherService>();
            weatherService.Setup(s => s.GetWeather("Australia", "NotExistingCity"))
                .ReturnsAsync(null);

            var controller = new WeatherController(weatherService.Object);
            var result = await controller.Get("Australia", "NonExistingCity");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
