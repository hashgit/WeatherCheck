using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherCheck.Services
{
    public interface ICityService
    {
        Task<IEnumerable<string>> GetCities(string country);
    }

    public class CityService : ICityService
    {
        public async Task<IEnumerable<string>> GetCities(string country)
        {
            var client = new GlobalWeather.GlobalWeatherSoapClient();
            var cities = await client.GetCitiesByCountryAsync(country);

            return new List<string>();
        }
    }
}