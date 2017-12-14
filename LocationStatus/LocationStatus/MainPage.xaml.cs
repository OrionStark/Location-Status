using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform;
using Xamarin.Forms.PlatformConfiguration;
using Newtonsoft.Json;
using LocationStatus.Model;

namespace LocationStatus
{
	public partial class MainPage : ContentPage
	{
		Weather weather = new Weather();
		public MainPage()
		{
			InitializeComponent();
#if __ANDROID__
			img_icon.Source = ImageSource.FromResource("LocationStatus.Droid.Resources.Drawable.cloudicon.png");
#elif __IOS__
			img_icon.Source = ImageSource.FromResource("LocationStatus.iOS.Resources.cloudicon.png");
#else
			img_icon.Source = ImageSource.FromResource("LocationStatus.UWP.cloudicon.png");
#endif
			submit_btn.Clicked += (o, e) =>
			{
				try
				{
#if SILVERLIGHT
					weather.getCurrentWeather(City_Field.Text, Weather.MODE.JSON_MODE);
					Navigation.PushAsync(new WeatherStatus(this.weather.weather));
#else
					weather.getCurrentWeather(City_Field.Text, Weather.MODE.XML_MODE);
					Navigation.PushAsync(new WeatherStatus(this.weather.weather_xml), true);
#endif
					//condition.Text = weather.weather_xml.condition;
				}
				catch {
					DisplayAlert("Something went Wrong", "Please check your internet connection/n" +
						"or the API isn't ready yet", "OK");
				}
			};
		}
		protected override void OnDisappearing()
		{
			this.City_Field.Text = "";
		}
	}
}
