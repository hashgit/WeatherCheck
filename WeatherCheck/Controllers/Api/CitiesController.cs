using System;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherCheck.Services;

namespace WeatherCheck.Controllers.Api
{
    [RoutePrefix("api/Cities")]
    public class CitiesController : ApiController
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [Route("")]
        public async Task<IHttpActionResult> Get(string country)
        {
            try
            {
                var cities = await _cityService.GetCities(country);
                return Ok(cities);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
