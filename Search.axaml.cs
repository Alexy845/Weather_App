using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Weather_App;

public partial class Search : Window
{
    public WeatherApi WeatherApi = new WeatherApi();
    public Search()
    {
        InitializeComponent();
    }

    private void SearchButton_Click(object? sender, RoutedEventArgs routedEventArgs)
    {
        if (SearchBox.Text != null && CountryBox.Text != null)
                GetWeather(SearchBox.Text, CountryBox.Text);
    }

    public async void GetWeather(string ville, string pays)
    {
        var weather = await WeatherApi.GetWeatherForecast(ville, pays);
        if (weather != null)
        {
            var items = new ObservableCollection<string>(){};
            var coord = weather.coord;
            var weatherList = weather.weather;
            var main = weather.main;
            var wind = weather.wind;
            var sys = weather.sys;
            var clouds = weather.clouds;
            var rain = weather.rain;
            var snow = weather.snow;
            var dt = weather.dt;
            var id = weather.id;
            var name = weather.name;
            var cod = weather.cod;
            var baseWeather = weather.@base;
            var visibility = weather.visibility;
            var timezone = weather.timezone;

            items.Add($"Coord : {coord.lon} ; {coord.lat}");
            items.Add($"Weather : {weatherList[0].id} ; {weatherList[0].main} ; {weatherList[0].description} ; {weatherList[0].icon}");
            items.Add($"Main : {main.temp} ; {main.feels_like} ; {main.temp_min} ; {main.temp_max} ; {main.pressure} ; {main.humidity} ; {main.sea_level} ; {main.grnd_level}");
            items.Add($"Wind : {wind.speed} ; {wind.deg} ; {wind.gust}");
            items.Add($"Sys : {sys.type} ; {sys.id} ; {sys.country} ; {sys.sunrise} ; {sys.sunset}");
            items.Add($"Clouds : {clouds.all}");
            if (rain is not null)
            {
                if (rain._1h != 0)
                {
                    items.Add($"Rain : {rain._1h}");
                }
                else
                {
                    items.Add($"Rain : {rain._3h}");
                }
            }
            
            if (snow is not null)
            {
                if (snow._1h != 0)
                {
                    items.Add($"Snow : {snow._1h}");
                }
                else
                {
                    items.Add($"Snow : {snow._3h}");
                }
            }
            items.Add($"Dt : {dt}");
            items.Add($"Id : {id}");
            items.Add($"Name : {name}");
            items.Add($"Cod : {cod}");
            items.Add($"Base : {baseWeather}");
            items.Add($"Visibility : {visibility}");
            items.Add($"Timezone : {timezone}");
            
            ResultsBox.ItemsSource = items;
        }
    }
}