namespace MauiWeatherApp.Extensions
{
    public static class Alerts
	{
        public static async Task DisplayAlert(string message,
                                               string buttonTxt = "OK",
                                               string title = "Warning")
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonTxt);
        }
    }
}

