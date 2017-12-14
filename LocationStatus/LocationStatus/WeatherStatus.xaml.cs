using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using LocationStatus.Model;
using LocationStatus.DataPack;

namespace LocationStatus
{
	public partial class WeatherStatus : ContentPage
	{
		protected override bool OnBackButtonPressed()
		{
			App.Current.MainPage.Navigation.PopAsync(true);
			return base.OnBackButtonPressed();
		}
		/// <summary>
		/// XML Mode
		/// </summary>
		/// <param name="data">XML object value</param>
		public WeatherStatus(Weather_XML_Data data)
		{
			InitializeComponent();
			//this.DATA = data;
			this.condition_lbl.Text = data.condition.First().ToString().ToUpper() +
				data.condition.Substring(1);
			this.temperature_lbl.Text += data.TEMP_IN_F + " F";
			this.wind_d_lbl.Text += data.Wind_direction.First().ToString().ToUpper() +
				data.Wind_direction.Substring(1);
			this.wind_type.Text += data.wind_type.First().ToString().ToUpper() +
				data.wind_type.Substring(1);
			this.wind_speed.Text += data.windspeed;
			this.city_name.Text = data.city.First().ToString().ToUpper() +
				data.city.Substring(1);
		}
		/// <summary>
		/// JDON Mode
		/// </summary>
		/// <param name="data">JSON object value</param>
		public WeatherStatus(Weather_Data data)
		{
			InitializeComponent();
			//this.JSON_Data = data;
			this.condition_lbl.Text = data.weather[0].description.First().ToString().ToUpper() 
				+ data.weather[0].main.Substring(1);
			this.wind_d_lbl.Text += data.wind.deg.ToString() + " Degrees";
			this.wind_speed.Text += data.wind.speed.ToString();
			this.temperature_lbl.Text += data.main.temp.ToString() + " F";
			this.city_name.Text = "Your Location Status";
		}
	}
}
