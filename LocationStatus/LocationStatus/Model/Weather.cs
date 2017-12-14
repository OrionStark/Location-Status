using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LocationStatus.DataPack;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms.Platform;
using Xamarin.Forms.PlatformConfiguration;
using System.Threading.Tasks;

namespace LocationStatus.Model
{
    class Weather
    {
		public enum MODE {
			JSON_MODE,
			XML_MODE
		}

		private const string ORION_API_KEY = "99ff815581920ce4a745369635fae80f";
		public Weather_Data weather { private set; get; }
		public Weather_XML_Data weather_xml { private set; get; }
		private HttpClient client;
		public MODE Mode;
		public Weather()
		{
			weather = new Weather_Data();
			weather_xml = new Weather_XML_Data();
		}
		private async Task getAsObjectAsync(string location)
		{
			var json = await getWeatherConditionAsync(location);
			Weather_Data data = JsonConvert.DeserializeObject<Weather_Data>(json);
			this.weather = data;
		}
		private async Task<string> getWeatherConditionAsync( string Location )
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			Uri url = new Uri(string.Format("http://api.openweathermap.org/data/2.5/weather?q=" + 
				Location + "&APPID=" + ORION_API_KEY));
			var response = await client.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				return content;
			}
			else {
				return response.ReasonPhrase;
			}
		}
		private void getWithXML(string Location)
		{
			System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument { XmlResolver = null };
			xmlDocument.Load(string.Format("http://api.openweathermap.org/data/2.5/weather?q=" 
				+ Location + "&mode=xml&units=imperial&APPID=" + ORION_API_KEY));
			this.weather_xml.city = xmlDocument.SelectSingleNode("current/city").Attributes["name"].InnerText;
			this.weather_xml.TEMP_IN_F = xmlDocument.SelectSingleNode("current/temperature").Attributes["value"].InnerText;
			this.weather_xml.LOW = xmlDocument.SelectSingleNode("current/temperature").Attributes["min"].InnerText;
			this.weather_xml.HIGH = xmlDocument.SelectSingleNode("current/temperature").Attributes["max"].InnerText;
			this.weather_xml.windspeed = xmlDocument.SelectSingleNode("current/wind/speed").Attributes["value"].InnerText;
			this.weather_xml.condition = xmlDocument.SelectSingleNode("current/weather").Attributes["value"].InnerText;
			this.weather_xml.Wind_direction = xmlDocument.SelectSingleNode("current/wind/direction").Attributes["name"].InnerText;
			this.weather_xml.wind_type = xmlDocument.SelectSingleNode("current/wind/speed").Attributes["name"].InnerText;
		}
		public void getCurrentWeather(string city, MODE mode)
		{
			switch (mode)
			{
				case MODE.JSON_MODE:
					this.getAsObjectAsync(city).RunSynchronously();
					break;
				case MODE.XML_MODE:
					this.getWithXML(city);
					break;
				default:
					this.getWithXML(city);
					break;
			}
		}

	}
}
