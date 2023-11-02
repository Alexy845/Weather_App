using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;

using Newtonsoft.Json;

namespace Weather_App;

public partial class MainWindow : Window
{
    public WeatherApi WeatherApi = new WeatherApi();
    public WeatherFiveDays WeatherFiveDays = new WeatherFiveDays();

    public string path = "../../../options.json";
    public MainWindow()
    {
        InitializeComponent();
        CreateJsonFile();
        SetSettings();
    }

    private void SetSettings()
    {
        string json = File.ReadAllText(path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        TemperatureComboBox.SelectedIndex = Int32.Parse(jsonObj["TempUnit"].ToString());
        LanguageComboBox.SelectedIndex = Int32.Parse(jsonObj["Language"].ToString());
        DefaultLocationTextBlock.Text = jsonObj["DefaultLocation"].ToString();
        DefaultCountryTextBlock.Text = jsonObj["DefaultCountry"].ToString();
    }

    private void CreateJsonFile()
    {
        if (!File.Exists(path))
        {
            var options = new
            {
                TempUnit = "0",
                Language = "10",
                DefaultLocation = "Bordeaux",
                DefaultCountry = "France"
            };
            string json = JsonConvert.SerializeObject(options, Formatting.Indented);
            File.WriteAllText(path, json);
            Console.WriteLine("creating file");
        }

    }
    private void ChangeTempUnit(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        string selectedContent = comboBox.SelectedIndex.ToString();
        string json = File.ReadAllText(path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        jsonObj["TempUnit"] = selectedContent;
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(path, output);
    }

    private void ChangeLanguage(object sender, SelectionChangedEventArgs e)
    {
        ComboBox comboBox = (ComboBox)sender;
        string selectedContent = comboBox.SelectedIndex.ToString();
        string json = File.ReadAllText(path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        jsonObj["Language"] = selectedContent;
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(path, output);
    }

    private async void SaveButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DefaultLocationTextBlock.Text == "" || DefaultCountryTextBlock.Text == "")
        {
            ErrorMessageBox.Text = "Error: Empty field";
            DefaultLocationTextBlock.Text = "Bordeaux";
            DefaultCountryTextBlock.Text = "France";
            return;
        }
        if (await WeatherApi.GetWeatherForecast(DefaultLocationTextBlock.Text, DefaultCountryTextBlock.Text) == null)
        {
            ErrorMessageBox.Text = "Error: Location not found";
            DefaultLocationTextBlock.Text = "Bordeaux";
            DefaultCountryTextBlock.Text = "France";
        }
        else
        {
            Console.WriteLine("Found");
            string json = File.ReadAllText(path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            jsonObj["DefaultLocation"] = DefaultLocationTextBlock.Text;
            jsonObj["DefaultCountry"] = DefaultCountryTextBlock.Text;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(path, output);
            ErrorMessageBox.Text = "Default Location saved";
        }
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

    private void SearchButtonPrev_Click(object? sender, RoutedEventArgs e)
    {
        if (SearchBarPrev.Text != null && CountryBarPrev.Text != null)
            GetWeatherFiveDays(SearchBarPrev.Text, CountryBarPrev.Text);
        TextBlock hehe = new TextBlock();
        hehe.Text= "hehe";
        TestPanel.Children.Add(hehe);
    }

    private async void GetWeatherFiveDays(string ville, string pays)
    {
        var weather = await WeatherFiveDays.GetWeatherFiveDays(ville, Conversion.GetCountryCode(pays));
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

    public void OnTabChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ErrorMessageBox is not null)
        {
            ErrorMessageBox.Text = "";
        }
    }
}