using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
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
        var weather = await WeatherApi.GetWeatherForecast(ville, Conversion.GetCountryCode(pays));
        if (weather != null)
        {
            var coord = weather.coord;
            var weatherList = weather.weather;
            var main = weather.main;
            var name = weather.name;

            NameBox.Text = ville;
            TempBox.Text = $"{Conversion.KelvinToCelsius(main.temp)}°C";
            DescBox.Text = weatherList[0].description;
            LatBox.Text = coord.lat.ToString(CultureInfo.CurrentCulture);
            LonBox.Text = coord.lon.ToString(CultureInfo.CurrentCulture);
            HumBox.Text = $"{main.humidity}%"; 
            
            Conversion.DownloadImageFromUrl($"http://openweathermap.org/img/w/{weatherList[0].icon}.png", "Images/icon.png");
            if (File.Exists("Images/icon.png")){
                ImageBox.Source = new Avalonia.Media.Imaging.Bitmap("Images/icon.png");
            }
        }
    }
}