using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Weather_App;

public partial class Search : Window
{
    public WeatherApi weatherApi = new WeatherApi();
    public Search()
    {
        InitializeComponent();
    }

    private void SearchBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is TextBox textBox)
        {
            GetWeather();
        }
    }
    
    public async void GetWeather()
    {
        var weather = await weatherApi.GetWeatherForecast();
        Console.WriteLine(weather);
    }
}