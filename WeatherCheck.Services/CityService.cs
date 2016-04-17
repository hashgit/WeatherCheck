using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using WeatherCheck.Services.Dto;

namespace WeatherCheck.Services
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetCities(string country);
    }

    public class CityService : ICityService
    {
        public async Task<IEnumerable<CityDto>> GetCities(string country)
        {
            var client = new GlobalWeather.GlobalWeatherSoapClient("GlobalWeatherSoap");
            var cities = await client.GetCitiesByCountryAsync(country);

            if (!string.IsNullOrWhiteSpace(cities))
            {
                var document = XDocument.Parse(cities);
                var cityElements = document.Root.XPathSelectElements("/NewDataSet/Table");
                return cityElements.Select(e => new CityDto { Country = e.Element("Country").Value, City = e.Element("City").Value });
            }

            return new List<CityDto>();
        }
    }
}