using System.IO;
using Newtonsoft.Json;

namespace Weather_App;

public class AppSettings
{
    public AppSettings(string defaultCity, string language)
    {
        DefaultCity = defaultCity;
        Language = language;
    }

    private AppSettings()
    {
        throw new System.NotImplementedException();
    }

    public string DefaultCity { get; set; }
    public string Language { get; set; }

    public static AppSettings Load(string optionsFilePath)
    {
        if (!File.Exists("options.json"))
        {
            return new AppSettings();
        }

        var json = File.ReadAllText("options.json");
        return JsonConvert.DeserializeObject<AppSettings>(json)!;
    }

    public void Save()
    {
        var json = JsonConvert.SerializeObject(this);
        File.WriteAllText("options.json", json);
    }
}