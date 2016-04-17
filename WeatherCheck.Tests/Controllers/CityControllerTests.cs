using System.Collections.Generic;
using System.Linq;
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
    public class CityControllerTests
    {
        [TestMethod]
        public async Task CanGetListOfCities()
        {
            var value = new List<CityDto>
            {
                new CityDto { City = "Sydney", Country = "Australia" },
                new CityDto { City = "Melbourne", Country = "Australia" }
            };

            var cityService = new Mock<ICityService>();
            cityService.Setup(s => s.GetCities("Australia"))
                .ReturnsAsync(value);

            var controller = new CitiesController(cityService.Object);
            var result = await controller.Get("Australia");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<CityDto>>));

            var resultObject = result as OkNegotiatedContentResult<IEnumerable<CityDto>>;
            Assert.AreEqual(value, resultObject.Content);
            Assert.AreEqual(2, resultObject.Content.Count());
        }

        [TestMethod]
        public async Task CountryNotFound()
        {
            var value = new List<CityDto>
            {
            };

            var cityService = new Mock<ICityService>();
            cityService.Setup(s => s.GetCities("NonExistingCountry"))
                .ReturnsAsync(value);

            var controller = new CitiesController(cityService.Object);
            var result = await controller.Get("NonExistingCountry");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<CityDto>>));

            var resultObject = result as OkNegotiatedContentResult<IEnumerable<CityDto>>;
            Assert.AreEqual(value, resultObject.Content);
            Assert.AreEqual(0, resultObject.Content.Count());
        }
    }
}
