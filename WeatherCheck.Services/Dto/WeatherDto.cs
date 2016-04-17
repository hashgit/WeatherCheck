/* 
Licensed under the Apache License, Version 2.0
    
http://www.apache.org/licenses/LICENSE-2.0
*/

using System.Xml.Serialization;

namespace WeatherCheck.Services.Dto
{
	[XmlRoot(ElementName="CurrentWeather")]
	public class WeatherDto {
		[XmlElement(ElementName="Location")]
		public string Location { get; set; }
		[XmlElement(ElementName="Time")]
		public string Time { get; set; }
		[XmlElement(ElementName="Wind")]
		public string Wind { get; set; }
		[XmlElement(ElementName="Visibility")]
		public string Visibility { get; set; }
		[XmlElement(ElementName="SkyConditions")]
		public string SkyConditions { get; set; }
		[XmlElement(ElementName="Temperature")]
		public string Temperature { get; set; }
		[XmlElement(ElementName="DewPoint")]
		public string DewPoint { get; set; }
		[XmlElement(ElementName="RelativeHumidity")]
		public string RelativeHumidity { get; set; }
		[XmlElement(ElementName="Pressure")]
		public string Pressure { get; set; }
		[XmlElement(ElementName="Status")]
		public string Status { get; set; }
	}
}
