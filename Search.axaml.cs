using System;
using System.Globalization;
using System.Linq;
using System.Text;
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
        weatherApi.GetCity(ville);
        while (!weatherApi.Ok)
        {
                
        }
        weatherApi.Ok = false;
        foreach (var i in weatherApi.AllCity)
        {
            
                var weather = await weatherApi.GetWeatherForecast(i.lat, i.lon);
                if (weather == null || !RemoveAccents(weather.name.ToLower()).Contains(RemoveAccents(ville.ToLower())))
                    continue;
                Console.WriteLine($"{weather.name} : {weather.id} -> {weather.coord.lon} ; {weather.coord.lat}" );
        }
    }
    static string RemoveAccents(string input)
    {
        string normalized = input.Normalize(NormalizationForm.FormD);
        StringBuilder builder = new StringBuilder();

        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(c);
            }
        }

        return builder.ToString();
    }
}