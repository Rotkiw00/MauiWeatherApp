using MauiWeatherApp.DataModels;
using Newtonsoft.Json;

namespace MauiWeatherApp.Repositories.Services
{
    public class WeatherRestService : IFetchingDataService
	{
		private readonly HttpClient _client;
		public WeatherRestService()
		{
			_client = new HttpClient();
		}

		public async Task<WeatherDataModel> GetCurrentWeatherDataAsync(string query)
		{
			WeatherDataModel weatherData = default;

            var apiResponse = await _client.GetAsync(query);

            if (apiResponse.IsSuccessStatusCode)
            {
                var content = await apiResponse.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(content);
            }

			return weatherData;
		}
	}
}

