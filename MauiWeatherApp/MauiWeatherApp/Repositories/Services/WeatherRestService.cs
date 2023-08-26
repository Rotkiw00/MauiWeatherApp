using MauiWeatherApp.DataModels;
using MauiWeatherApp.Extensions;
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

			try
			{
				var apiResponse = await _client.GetAsync(query);
                if (apiResponse.IsSuccessStatusCode())
                {
                    var content = await apiResponse.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(content);
                }
                else if (apiResponse.IsFailureStatusCode())
                {
                    await Alerts.DisplayAlert($"HttpResponsePhrase: {apiResponse.ReasonPhrase}");
                }
            }
			catch (InvalidOperationException ex)
			{
				await Alerts.DisplayAlert($"{ex.Message}");
			}
			catch (HttpRequestException ex)
			{
                await Alerts.DisplayAlert($"{ex.Message}");
            }
			catch (Exception ex)
			{
                await Alerts.DisplayAlert($"{ex.Message}");
            }        

			return weatherData;
		}
	}
}

