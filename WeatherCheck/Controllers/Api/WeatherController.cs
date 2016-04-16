using System;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherCheck.Services;

namespace WeatherCheck.Controllers.Api
{
    [RoutePrefix("api/Weather")]
    public class WeatherController : ApiController
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> Get(string country, string city)
        {
            try
            {
                var result = await _weatherService.GetWeather(country, city);
                return Ok(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
