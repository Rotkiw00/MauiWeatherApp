using MauiWeatherApp.DataModels;

namespace MauiWeatherApp.Repositories.Services
{
    public interface IFetchingDataService
	{
        public Task<WeatherDataModel> GetCurrentWeatherDataAsync(string query);
    }
}

