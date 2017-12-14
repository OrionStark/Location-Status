using System;
using System.Collections.Generic;
using System.Text;

namespace LocationStatus.DataPack
{
    public class Weather_XML_Data
    {
		public string city;
		public string windspeed;
		public string condition;
		public string TEMP_IN_F;
		public string Wind_direction;
		public string HIGH;
		public string LOW;
		public string wind_type;

		public Weather_XML_Data()
		{
			this.city = "No-Data";
			this.windspeed = "No-Data";
			this.condition = "No-Data";
			this.Wind_direction = "No-Data";
			this.TEMP_IN_F = "No-Data";
			this.HIGH = "No-Data";
			this.LOW = "No-Data";
			this.wind_type = "No-Data";
		}
	}
}
