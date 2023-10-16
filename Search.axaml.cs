using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.CodeAnalysis.CSharp;

namespace Weather_App;

public partial class Search : Window
{
    public WeatherApi weatherApi = new WeatherApi();
    public Search()
    {
        InitializeComponent();
    }

    private void SearchButton_Click(object? sender, RoutedEventArgs routedEventArgs)
    {
        GetWeather(searchBox.Text);
    }
    
    public async void GetWeather(string ville)
    {
        foreach (var i in weatherApi.GetAllCity())
        {
            if (i.name.ToLower().Contains(ville.ToLower()) && i.name.ToLower().StartsWith(ville.ToLower()))
            {
                var weather = await weatherApi.GetWeatherForecast(i.id.ToString());
                if (weather == null)
                    continue;
                Console.WriteLine($"{weather.name} : {weather.id} -> {weather.coord.lon} ; {weather.coord.lat}" );
            }
        }
    }
}