using MauiWeatherApp.DataModels;

namespace MauiWeatherApp.ViewModels
{
    public partial class WeatherDataViewModel
    {
        private WeatherDataModel _weatherDataModel;
        public WeatherDataModel WeatherDataModel
        {
            get => _weatherDataModel;
            set
            {
                _weatherDataModel = value;
                OnPropertyChanged();
            }
        }

        private string _cityEntryName;
        public string CityEntryName
        {
            get => _cityEntryName;
            set
            {
                _cityEntryName = value;
                OnPropertyChanged();
            }
        }

        private string _cityTitleName;
        public string CityTitleName
        {
            get => _cityTitleName;
            set
            {
                _cityTitleName = value;
                OnPropertyChanged();
            }
        }

        private string _temperature;
        public string Temperature
        {
            get => _temperature;
            set
            {
                _temperature = value;
                OnPropertyChanged();
            }
        }

        private string _weatherDescription;
        public string WeatherDescription
        {
            get => _weatherDescription;
            set
            {
                _weatherDescription = value;
                OnPropertyChanged();
            }
        }

        private string _pressure;
        public string Pressure
        {
            get => _pressure;
            set
            {
                _pressure = value;
                OnPropertyChanged();
            }
        }

        private string _windSpeed;
        public string WindSpeed
        {
            get => _windSpeed;
            set
            {
                _windSpeed = value;
                OnPropertyChanged();
            }
        }

        private string _sunsetTime;
        public string SunsetTime
        {
            get => _sunsetTime;
            set
            {
                _sunsetTime = value;
                OnPropertyChanged();
            }
        }

        private string _sunriseTime;
        public string SunriseTime
        {
            get => _sunriseTime;
            set
            {
                _sunriseTime = value;
                OnPropertyChanged();
            }
        }

        private string _weatherIconUrl;
        public string WeatherIconUrl
        {
            get => _weatherIconUrl;
            set
            {
                _weatherIconUrl = value;
                OnPropertyChanged();
            }
        }

        private string _humidity;
        public string Humidity
        {
            get => _humidity;
            set
            {
                _humidity = value;
                OnPropertyChanged();
            }
        }

        private string _temperatureMin;
        public string TemperatureMin
        {
            get => _temperatureMin;
            set
            {
                _temperatureMin = value;
                OnPropertyChanged();
            }
        }

        private string _temperatureMax;
        public string TemperatureMax
        {
            get => _temperatureMax;
            set
            {
                _temperatureMax = value;
                OnPropertyChanged();
            }
        }

        private string _visibility;
        public string Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }
    }
}

