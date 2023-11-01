using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Weather_App;

public partial class MainWindow : Window
{
    public WeatherApi WeatherApi = new WeatherApi();
    public MainWindow()
    {
        InitializeComponent();
    }
    private void SearchButton_Click(object? sender, RoutedEventArgs eventArgs)
    {
        if (SearchBar.Text != null && CountryBar.Text != null)
                GetWeather(SearchBar.Text, CountryBar.Text);
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
            var name = weather.name;
            
            items.Add($"Name : {name}");
            items.Add($"Temperature : {KelvinToCelsius(main.temp)}°C");
            items.Add($"Description du temps : {weatherList[0].description}");
            items.Add($"Latitude : {coord.lat}");
            items.Add($"Longitude : {coord.lon}");
            items.Add($"Humidity : {main.humidity}%");
            
            ResultsBox.ItemsSource = items;
        }
    }
    
    public float KelvinToCelsius(float kelvin)
    {
        return (float)Math.Floor(kelvin - 273.15f);
    }
}