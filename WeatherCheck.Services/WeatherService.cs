using System.Threading.Tasks;

namespace WeatherCheck.Services
{
    public interface IWeatherService
    {
        Task<string> GetWeather(string country, string city);
    }

    public class WeatherService : IWeatherService
    {
        public async Task<string> GetWeather(string country, string city)
        {
            var client = new GlobalWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
            var weather = await client.GetWeatherAsync(city, country);

            return weather;
        }
    }
}