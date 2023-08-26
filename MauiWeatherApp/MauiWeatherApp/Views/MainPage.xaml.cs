using MauiWeatherApp.ViewModels;

namespace MauiWeatherApp;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
		BindingContext = new WeatherDataViewModel();
	}
}

/*
 * 3. Zastanowić się nad bazą danych przechowującą zapisane miasta
 * 4. Czyszczenie strony/pola wyszukiwania pod określonym warunkiem
 * 6. Zrefaktorować kod pod kątem lepszych praktyk programowania [W trakcie..]
 */