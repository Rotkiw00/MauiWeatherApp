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
			_service = new WeatherRestService();
			GetWeather_Command = new Command(async () =>
                await GetWeatherDataBySearchedCityAsync());
            SetDefaultValuesToProperties();
		}	

		private async Task GetWeatherDataBySearchedCityAsync()
		{
            if (!String.IsNullOrWhiteSpace(CityEntryName))
            {
                string query = $"{WeatherApiConnectionDetails.WEATHER_API_URI_ENDPOINT}?q={CityEntryName}&lang=pl&appid={WeatherApiConnectionDetails.WEATHER_API_KEY}&units=metric";

                WeatherDataModel = await _service.GetCurrentWeatherDataAsync(query);
                InitializeWeatherDataModelProperties();
            }
        }       

        private void InitializeWeatherDataModelProperties()
        {
            CityTitleName = WeatherDataModel.Title;
            Temperature = ((int)WeatherDataModel.Main.Temperature).ToString();
            SunriseTime = UnixTimeStampToDateTime(WeatherDataModel.Sys.Sunrise);
            WeatherDescription = WeatherDataModel.Weather[0].Description;
            Pressure = ((int)WeatherDataModel.Main.Pressure).ToString();
            WindSpeed = WeatherDataModel.Wind.Speed.ToString("0.##");
            SunsetTime = UnixTimeStampToDateTime(WeatherDataModel.Sys.Sunset);
        }

        private void SetDefaultValuesToProperties()
        {
            CityTitleName = " ";
            Temperature = "--";
            WeatherDescription = " ";
            SunriseTime = "--";
            Pressure = "--";
            WindSpeed = "--";
            SunsetTime = "--";
        }

        public static string UnixTimeStampToDateTime(long unixTimeStamp)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime.ToString("T");
        }
    }
}

