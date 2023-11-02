using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Newtonsoft.Json;
using Weather_App.Enum;
using static System.Console;

namespace Weather_App;

public partial class MainWindow : Window
{
    public WeatherApi WeatherApi = new WeatherApi();
    public WeatherFiveDays WeatherFiveDays = new WeatherFiveDays();

    public string Path = "options.json";

    public List<StackPanel> AllPanel = new List<StackPanel>();
    public static UnitTemp UnitTemp;
    public static Country Country;

    public MainWindow()
    {
        InitializeComponent();
        CreateJsonFile();
        SetSettings();
        AllPanel.Add(PanelDay1);
        AllPanel.Add(PanelDay2);
        AllPanel.Add(PanelDay3);
        AllPanel.Add(PanelDay4);
        AllPanel.Add(PanelDay5);
    }
    
    
    private void ChangeUnit(int index)
    {
        if (index == 0)
        {
            UnitTemp = UnitTemp.Celsius;
        }
        else if (index == 1)
        {
            UnitTemp = UnitTemp.Fahrenheit;
        }
        else
        {
            UnitTemp = UnitTemp.Kelvin;
        }
    }

    private void SetSettings()
    {
        string json = File.ReadAllText(Path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        TemperatureComboBox.SelectedIndex = Int32.Parse(jsonObj["TempUnit"].ToString());
        ChangeUnit(Int32.Parse(jsonObj["TempUnit"].ToString()));
        LanguageComboBox.SelectedIndex = Int32.Parse(jsonObj["Language"].ToString());
        SetCountry.SetCountryEnum(LanguageComboBox.SelectedIndex);
        DefaultLocationTextBlock.Text = jsonObj["DefaultLocation"].ToString();
    }

    private void CreateJsonFile()
    {
        if (!File.Exists(Path))
        {
            var options = new
            {
                TempUnit = "0",
                Language = "10",
                DefaultLocation = "Bordeaux"
            };
            string json = JsonConvert.SerializeObject(options, Formatting.Indented);
            File.WriteAllText(Path, json);
            WriteLine("creating file");
        }
    }

    private void ChangeTempUnit(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        ChangeUnit(comboBox.SelectedIndex);
        string selectedContent = comboBox.SelectedIndex.ToString();
        string json = File.ReadAllText(Path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        jsonObj["TempUnit"] = selectedContent;
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(Path, output);
    }

    private void ChangeLanguage(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        string selectedContent = comboBox.SelectedIndex.ToString();
        SetCountry.SetCountryEnum(comboBox.SelectedIndex);
        string json = File.ReadAllText(Path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        jsonObj["Language"] = selectedContent;
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(Path, output);
    }

    private void DefaultLocationTextBlock_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        string json = File.ReadAllText(Path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        jsonObj["DefaultLocation"] = DefaultLocationTextBlock.Text;
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(Path, output);
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
            if (UnitTemp == UnitTemp.Celsius)
            {
                TempBox.Text = $"{Conversion.KelvinToCelsius(main.temp)}°C";
            }
            else if (UnitTemp == UnitTemp.Fahrenheit)
            {
                TempBox.Text = $"{Conversion.KelvinToFahrenheit(main.temp)}°F";
            }
            else
            {
                TempBox.Text = $"{main.temp}°K";
            }

            DescBox.Text = weatherList[0].description;
            LatBox.Text = coord.lat.ToString(CultureInfo.CurrentCulture);
            LonBox.Text = coord.lon.ToString(CultureInfo.CurrentCulture);
            HumBox.Text = $"{main.humidity}%";

            Conversion.DownloadImageFromUrl($"http://openweathermap.org/img/w/{weatherList[0].icon}.png",
                "Images/icon.png");
            if (File.Exists("Images/icon.png"))
            {
                ImageBox.Source = new Avalonia.Media.Imaging.Bitmap("Images/icon.png");
            }
        }
    }

    private void SearchButtonPrev_Click(object? sender, RoutedEventArgs e)
    {
        if (SearchBarPrev.Text is not null || CountryBarPrev.Text is not null)
        {
            GetWeatherFiveDays(SearchBarPrev.Text, CountryBarPrev.Text);
        }
    }

    private async void GetWeatherFiveDays(string ville, string pays)
    {
        if (ville.Length == 0 || pays.Length == 0) return;
        var weather = await WeatherFiveDays.GetWeatherFiveDays(ville, Conversion.GetCountryCode(pays));
        if (weather != null)
        {
            var coord = weather.city.coord;
            var name = weather.city.name;

            var fivesDays = new List<WeatherFiveDays.Weather5Days.Day>();
            
            NameBoxPrev.Text = name;
            LatBoxPrev.Text = coord.lat.ToString(CultureInfo.CurrentCulture);
            LonBoxPrev.Text = coord.lon.ToString(CultureInfo.CurrentCulture);

            foreach (var i in weather.list)
            {
                if (i.dt_txt.Contains("12:00:00"))
                {
                    fivesDays.Add(i);
                }
            }
            
            for (int i = 0; i < AllPanel.Count; i++)
            {
                TextBlock date = new AccessText();
                TextBlock temp = new TextBlock();
                TextBlock desc = new TextBlock();
                TextBlock hum = new TextBlock();
                Image image = new Image();

                date.Text = fivesDays[i].dt_txt;
                if (UnitTemp == UnitTemp.Celsius)
                {
                    temp.Text = $"{Conversion.KelvinToCelsius(fivesDays[i].main.temp)}°C";
                }
                else if (UnitTemp == UnitTemp.Fahrenheit)
                {
                    temp.Text = $"{Conversion.KelvinToFahrenheit(fivesDays[i].main.temp)}°F";
                }
                else
                {
                    temp.Text = $"{fivesDays[i].main.temp}°K";
                }

                desc.Text = fivesDays[i].weather[0].description;
                hum.Text = $"{fivesDays[i].main.humidity}%";

                AllPanel[i].Children.Clear();
                AllPanel[i].Children.Add(date);
                AllPanel[i].Children.Add(temp);
                AllPanel[i].Children.Add(desc);
                AllPanel[i].Children.Add(hum);
                Conversion.DownloadImageFromUrl($"http://openweathermap.org/img/w/{fivesDays[i].weather[0].icon}.png",
                    $"Images/iconPrev{i.ToString()}.png");
                if (File.Exists($"Images/iconPrev{i.ToString()}.png"))
                {
                    image.Source = new Avalonia.Media.Imaging.Bitmap($"Images/iconPrev{i.ToString()}.png");
                    image.Width = 50;
                    image.Height = 50;
                    AllPanel[i].Children.Add(image);
                }
            }
        }
    }
}