namespace MauiWeatherApp.Extensions
{
    public static class ExtensionMethods
	{
        public static string UnixTimeStampToDateTime(this long unixTimeStamp)
        {
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime.ToString("T");
        }

        public static bool IsSuccessStatusCode(this HttpResponseMessage response) =>
            response.IsSuccessStatusCode;

        public static bool IsFailureStatusCode(this HttpResponseMessage response)
        {
            return response.StatusCode >= (System.Net.HttpStatusCode)400 &&
                   response.StatusCode <= (System.Net.HttpStatusCode)499;
        }
    }
}

