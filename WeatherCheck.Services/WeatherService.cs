using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeatherCheck.Services.Dto;

namespace WeatherCheck.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeather(string country, string city);
    }

    public class WeatherService : IWeatherService
    {
        public async Task<WeatherDto> GetWeather(string country, string city)
        {
            var client = new GlobalWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
            var weather = await client.GetWeatherAsync(city, country);

            if (string.Equals(weather, "data not found", StringComparison.CurrentCultureIgnoreCase))
               return null;

            var serializer = new XmlSerializer(typeof (WeatherDto));
            using (var reader = new StringReader(weather))
            {
                var dto = (WeatherDto) serializer.Deserialize(reader);
                return dto;
            }
        }
    }
}