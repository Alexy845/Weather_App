using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Newtonsoft.Json;
using Weather_App.API;
using Weather_App.Enum;

namespace Weather_App;

public partial class MainWindow : Window
{
    private readonly WeatherApi _weatherApi = new WeatherApi();
    private readonly WeatherFiveDays _weatherFiveDays = new WeatherFiveDays();

    private const string Path = "options.json";

    private readonly List<Panel> _allPanel = new List<Panel>();
    private UnitTemp unitTemp { get; set; }
    public static Country country { get; set; }
    private static string? defaultLocation { get; set; }
    private static string? defaultCountry { get; set; }
    private static string? lastLocation { get; set; }
    private static string? lastCountry { get; set; }
    private static string? lastLocationPrev { get; set; }
    private static string? lastCountryPrev { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        CreateJsonFile();
        SetSettings();
        _allPanel.Add(PanelDay1);
        _allPanel.Add(PanelDay2);
        _allPanel.Add(PanelDay3);
        _allPanel.Add(PanelDay4);
        _allPanel.Add(PanelDay5);
        ReloadSearch();
    }


    private void ChangeUnit(int index)
    {
        if (index == 0)
        {
            unitTemp = UnitTemp.Celsius;
        }
        else if (index == 1)
        {
            unitTemp = UnitTemp.Fahrenheit;
        }
        else
        {
            unitTemp = UnitTemp.Kelvin;
        }
    }

    private void SetSettings()
    {
        try
        {
            string json = File.ReadAllText(Path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json) ?? throw new Microsoft.CSharp.RuntimeBinder.RuntimeBinderException();
            TemperatureComboBox.SelectedIndex = Int32.Parse(jsonObj["TempUnit"].ToString());
            ChangeUnit(Int32.Parse(jsonObj["TempUnit"].ToString()));
            LanguageComboBox.SelectedIndex = Int32.Parse(jsonObj["Language"].ToString());
            SetCountry.SetCountryEnum(LanguageComboBox.SelectedIndex);
            DefaultLocationTextBlock.Text = jsonObj["DefaultLocation"].ToString();
            DefaultCountryTextBlock.Text = jsonObj["DefaultCountry"].ToString();
            defaultLocation = jsonObj["DefaultLocation"].ToString();
            defaultCountry = jsonObj["DefaultCountry"].ToString();
        }
        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
        {
            CreateJsonFile(true);
        }
    }

    private void CreateJsonFile(bool force = false)
    {
        if (!File.Exists(Path) || force)
        {
            var options = new
            {
                TempUnit = "0",
                Language = "10",
                DefaultLocation = "Bordeaux",
                DefaultCountry = "France"
            };
            string json = JsonConvert.SerializeObject(options, Formatting.Indented);
            File.WriteAllText(Path, json);
            if (force) SetSettings();
        }
    }

    private void ChangeTempUnit(object sender, SelectionChangedEventArgs _)
    {
        try
        {
            ComboBox comboBox = (ComboBox)sender;
            ChangeUnit(comboBox.SelectedIndex);
            string selectedContent = comboBox.SelectedIndex.ToString();
            string json = File.ReadAllText(Path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json) ?? throw new InvalidOperationException();
            jsonObj["TempUnit"] = selectedContent;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Path, output);
            ReloadSearch();
        }
        catch (InvalidOperationException)
        {
            CreateJsonFile(true);
        }
    }

    private void ReloadSearch()
    {
        if (lastLocation is not null && lastCountry is not null)
        {
            GetWeather(lastLocation, lastCountry);
        }
        else
        {
            if (defaultLocation is not null && defaultCountry is not null) GetWeather(defaultLocation, defaultCountry);
        }

        if (lastLocationPrev is not null && lastCountryPrev is not null)
        {
            GetWeatherFiveDays(lastLocationPrev, lastCountryPrev);
        }
        else
        {
            if (defaultLocation is not null && defaultCountry is not null)
                GetWeatherFiveDays(defaultLocation, defaultCountry);
        }
    }

    private void ChangeLanguage(object sender, SelectionChangedEventArgs _)
    {
        try
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedContent = comboBox.SelectedIndex.ToString();
            SetCountry.SetCountryEnum(comboBox.SelectedIndex);
            string json = File.ReadAllText(Path);
            dynamic jsonObj = JsonConvert.DeserializeObject(json) ?? throw new InvalidOperationException();
            jsonObj["Language"] = selectedContent;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(Path, output);
            ReloadSearch();
        }
        catch (InvalidOperationException)
        {
            CreateJsonFile(true);
        }
    }

    private async void SaveButton_OnClick(object? sender, RoutedEventArgs _)
    {
        if (!NetworkInterface.GetIsNetworkAvailable() || !Internet.DnsTest())
        {
            var window = new NoInternet();
            window.Show();
            Close();
        }
        if (DefaultLocationTextBlock.Text == "" || DefaultCountryTextBlock.Text == "" || DefaultLocationTextBlock.Text is null || DefaultCountryTextBlock.Text is null)
        {
            ErrorMessageBox.Text = "Error: Empty field";
            DefaultLocationTextBlock.Text = "Bordeaux";
            DefaultCountryTextBlock.Text = "France";
            return;
        }

        if (await _weatherApi.GetWeatherForecast(DefaultLocationTextBlock.Text, DefaultCountryTextBlock.Text) == null)
        {
            ErrorMessageBox.Text = "Error: Location not found";
            DefaultLocationTextBlock.Text = "Bordeaux";
            DefaultCountryTextBlock.Text = "France";
        }
        else
        {
            try
            {
                string json = await File.ReadAllTextAsync(Path);
                dynamic jsonObj = JsonConvert.DeserializeObject(json) ?? throw new InvalidOperationException();
                jsonObj["DefaultLocation"] = DefaultLocationTextBlock.Text;
                jsonObj["DefaultCountry"] = DefaultCountryTextBlock.Text;
                string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                await File.WriteAllTextAsync(Path, output);
                defaultLocation = DefaultLocationTextBlock.Text;
                defaultCountry = DefaultCountryTextBlock.Text;
                ReloadSearch();
                ErrorMessageBox.Text = "Default Location saved";
            }
            catch (InvalidOperationException)
            {
                CreateJsonFile(true);
            }
        }
    }

    private void SearchButton_Click(object? sender, RoutedEventArgs _)
    {
        if (SearchBar.Text is not null && CountryBar.Text is not null && SearchBar.Text.Length != 0 && CountryBar.Text.Length != 0)
            GetWeather(SearchBar.Text, CountryBar.Text);
        else
        {
            GetWeather(defaultLocation, defaultCountry);
        }
    }

    private async void GetWeather(string? ville, string? pays)
    {
        if (!NetworkInterface.GetIsNetworkAvailable() || !Internet.DnsTest())
        {
            var window = new NoInternet();
            window.Show();
            Close();
        }
        if (ville is null || pays is null || ville.Length == 0 || pays.Length == 0) return;
        var weather = await _weatherApi.GetWeatherForecast(ville, Conversion.GetCountryCode(pays));
        if (weather is not null)
        {
            lastLocation = ville;
            lastCountry = pays;
            var coordinate = weather.coord;
            var weatherList = weather.weather;
            var main = weather.main;

            NameBox.Text = ville;
            if (unitTemp == UnitTemp.Celsius)
            {
                TempBox.Text = $"{Conversion.KelvinToCelsius(main.temp)}°C";
            }
            else if (unitTemp == UnitTemp.Fahrenheit)
            {
                TempBox.Text = $"{Conversion.KelvinToFahrenheit(main.temp)}°F";
            }
            else
            {
                TempBox.Text = $"{main.temp}°K";
            }

            DescBox.Text = weatherList[0].description;
            LatBox.Text = $"Latitude: {coordinate.lat.ToString(CultureInfo.CurrentCulture)}";
            LonBox.Text = $"Longitude: {coordinate.lon.ToString(CultureInfo.CurrentCulture)}";
            HumBox.Text = $"{main.humidity}%";

            Conversion.DownloadImageFromUrl($"http://openweathermap.org/img/w/{weatherList[0].icon}.png",
                "Images/icon.png");
            if (File.Exists("Images/icon.png"))
            {
                ImageBox.Source = new Avalonia.Media.Imaging.Bitmap("Images/icon.png");
            }
        }
    }

    private void SearchButtonPrev_Click(object? sender, RoutedEventArgs _)
    {
        if (SearchBarPrev.Text is not null && CountryBarPrev.Text is not null && SearchBarPrev.Text.Length != 0 && CountryBarPrev.Text.Length != 0)
        {
            GetWeatherFiveDays(SearchBarPrev.Text, CountryBarPrev.Text);
        }
        else
        {
            GetWeatherFiveDays(defaultLocation, defaultCountry);
        }
    }

    private async void GetWeatherFiveDays(string? ville, string? pays)
    {
        if (!NetworkInterface.GetIsNetworkAvailable() || !Internet.DnsTest())
        {
            var window = new NoInternet();
            window.Show();
            Close();
        }
        if (ville is null || pays is null || ville.Length == 0 || pays.Length == 0) return;
        var weather = await _weatherFiveDays.GetWeatherFiveDays(ville, Conversion.GetCountryCode(pays));
        if (weather is null) return;
        lastLocationPrev = ville;
        lastCountryPrev = pays;
        var coordinate = weather.city?.coord;
        var name = weather.city?.name;

        var fivesDays = new List<WeatherFiveDays.Weather5Days.Day>();

        NameBoxPrev.Text = name;
        LatBoxPrev.Text = $"Latitude: {coordinate?.lat.ToString(CultureInfo.CurrentCulture)}";
        LonBoxPrev.Text = $"Longitude: {coordinate?.lon.ToString(CultureInfo.CurrentCulture)}";

        if (weather.list is null) return;
        
        foreach (var i in weather.list)
        {
            if (i.dt_txt is not null && i.dt_txt.Contains("12:00:00"))
            {
                fivesDays.Add(i);
            }
        }
        if (fivesDays.Count != _allPanel.Count) return;
        for (int i = 0; i < _allPanel.Count; i++)
        {
            Grid grid = new Grid();
            Rectangle rectangle = new Rectangle();
            TextBlock date = new AccessText();
            TextBlock temp = new TextBlock();
            TextBlock desc = new TextBlock();
            TextBlock hum = new TextBlock();
            Image image = new Image();
            Image imgHum = new Image();


            for (int j = 0; j < 4; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            rectangle.Fill = new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.Parse("#03001C"));
            rectangle.Width = 250;
            rectangle.Height = 230;
            rectangle.RadiusX = 10;
            rectangle.RadiusY = 10;
            rectangle.Opacity = 0.3;

            date.Text = fivesDays[i].dt_txt;
            if (unitTemp == UnitTemp.Celsius)
            {
                temp.Text = $"{Conversion.KelvinToCelsius(fivesDays[i].main.temp)}°C";
            }
            else if (unitTemp == UnitTemp.Fahrenheit)
            {
                temp.Text = $"{Conversion.KelvinToFahrenheit(fivesDays[i].main.temp)}°F";
            }
            else
            {
                temp.Text = $"{fivesDays[i].main.temp}°K";
            }

            desc.Text = fivesDays[i].weather[0].description;
            hum.Text = $"{fivesDays[i].main.humidity}%";

            date.Margin = new Thickness(60, 20, 0, 0);
            temp.Margin = new Thickness(20, 40, 0, 0);
            temp.FontSize = 30;
            desc.Margin = new Thickness(20, 20, 0, 0);
            hum.Margin = new Thickness(34, 10, 0, 0);
            image.Margin = new Thickness(-80, 0, 0, 0);
            imgHum.Margin = new Thickness(-150, 8.5, 0, 0);

            if (File.Exists("Images/Humidity.png"))
            {
                imgHum.Source = new Avalonia.Media.Imaging.Bitmap("Images/Humidity.png");
                imgHum.Width = 20;
                imgHum.Height = 20;
                imgHum.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                imgHum.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Top;
                grid.Children.Add(imgHum);
                Grid.SetRow(imgHum, 3);
                Grid.SetColumn(imgHum, 0);
            }

            Grid.SetRow(date, 0);
            Grid.SetRow(temp, 1);
            Grid.SetRow(desc, 2);
            Grid.SetRow(hum, 3);
            Grid.SetColumn(date, 0);
            Grid.SetColumn(temp, 0);
            Grid.SetColumn(desc, 0);
            Grid.SetColumn(hum, 0);

            _allPanel[i].Children.Clear();
            _allPanel[i].Children.Add(rectangle);
            grid.Children.Add(date);
            grid.Children.Add(temp);
            grid.Children.Add(desc);
            grid.Children.Add(hum);
            _allPanel[i].Children.Add(grid);
            Conversion.DownloadImageFromUrl($"http://openweathermap.org/img/w/{fivesDays[i].weather[0].icon}.png",
                $"Images/iconPrev{i.ToString()}.png");
            if (File.Exists($"Images/iconPrev{i.ToString()}.png"))
            {
                image.Source = new Avalonia.Media.Imaging.Bitmap($"Images/iconPrev{i.ToString()}.png");
                image.Width = 100;
                image.Height = 100;
                image.VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center;
                image.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                grid.Children.Add(image);
                Grid.SetRow(image, 3);
                Grid.SetColumn(image, 1);
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