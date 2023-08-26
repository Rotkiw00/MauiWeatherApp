using MauiWeatherApp.Extensions;
using System.Windows.Input;
using MauiWeatherApp.DataModels;
using MauiWeatherApp.Repositories.Services;

namespace MauiWeatherApp.ViewModels
{
    public partial class WeatherDataViewModel : ViewBaseModel
	{
		private readonly IFetchingDataService _service;
		public ICommand GetWeather_Command { get; }

		public WeatherDataViewModel()
		{
            SetDefaultValuesToProperties();

			_service = new WeatherRestService();

            GetWeather_Command = new Command(async () =>
                await GetWeatherDataBySearchedCityAsync());
		}

        private void SetDefaultValuesToProperties()
        {
            CityTitleName = " ";
            Temperature = "--";
            TemperatureMin = "--";
            TemperatureMax = "--";
            WeatherDescription = " ";
            SunriseTime = "--";
            Pressure = "--";
            WindSpeed = "--";
            SunsetTime = "--";
            Humidity = "--";
            Visibility = "--";
        }

        private async Task GetWeatherDataBySearchedCityAsync()
		{
            if (!String.IsNullOrWhiteSpace(CityEntryName))
            {
                string query = $"{WeatherApiConnectionDetails.WEATHER_API_URI_ENDPOINT}" +
                    $"?q={CityEntryName}" +
                    $"&lang=en&" +
                    $"appid={WeatherApiConnectionDetails.WEATHER_API_KEY}" +
                    $"&units=metric";

                WeatherDataModel = await _service.GetCurrentWeatherDataAsync(query);
                if (WeatherDataModel is null)
                {
                    await Alerts.DisplayAlert("Cannot fetch data. Wrong city name probably");
                }
                else
                {
                    InitializeWeatherDataModelProperties();
                }
            }
            else
            {
                ClearCityNameEntry();
                await Alerts.DisplayAlert("Search tab is empty. Please enter the city name");
            }
        }        

        private void InitializeWeatherDataModelProperties()
        {
            GetCityName();
            GetTemperature();
            GetSunriseAndSunsetTime();
            GetWeatherDescription();
            GetPressure();
            GetWindSpeed();            
            GetWeatherIcon();
            GetHumidity();
            GetVisibility();

            ClearCityNameEntry();
        }       

        private void GetCityName()
        {
            CityTitleName = WeatherDataModel.Title;
        }

        private void GetTemperature()
        {
            Temperature = ((int)WeatherDataModel.Main.Temperature).ToString();
            TemperatureMin = ((int)WeatherDataModel.Main.TempMin).ToString();
            TemperatureMax = ((int)WeatherDataModel.Main.TempMax).ToString();
        }

        private void GetSunriseAndSunsetTime()
        {
            SunriseTime = WeatherDataModel.Sys.Sunrise.UnixTimeStampToDateTime();
            SunsetTime = WeatherDataModel.Sys.Sunset.UnixTimeStampToDateTime();
        }

        private void GetWeatherDescription()
        {
            WeatherDescription = WeatherDataModel.Weather[0].Description;
        }

        private void GetPressure()
        {
            Pressure = ((int)WeatherDataModel.Main.Pressure).ToString();
        }

        private void GetWindSpeed()
        {
            WindSpeed = (WeatherDataModel.Wind.Speed * 3.6).ToString("0.##");
        }

        private void GetWeatherIcon()
        {
            string codeIcon = WeatherDataModel.Weather[0].Icon;
            WeatherIconUrl = $"https://openweathermap.org/img/wn/{codeIcon}@2x.png";
        }

        private void GetHumidity()
        {
            Humidity = WeatherDataModel.Main.Humidity.ToString();
        }

        private void GetVisibility()
        {
            Visibility = (WeatherDataModel.Visibility / 1_000).ToString();
        }

        private void ClearCityNameEntry() => CityEntryName = "";
    }
}

