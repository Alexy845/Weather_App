using System;
using System.IO;
using Avalonia.Controls;
using Newtonsoft.Json;

namespace Weather_App;

public partial class MainWindow : Window
{
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
    }

    private void CreateJsonFile()
    {
        if (!File.Exists(path))
        {
            var options = new
            {
                TempUnit = "0",
                Language = "10",
                DefaultLocation = "Bordeaux"
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

    private void DefaultLocationTextBlock_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        string json = File.ReadAllText(path);
        dynamic jsonObj = JsonConvert.DeserializeObject(json);
        jsonObj["DefaultLocation"] = DefaultLocationTextBlock.Text;
        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
        File.WriteAllText(path, output);
    }
}