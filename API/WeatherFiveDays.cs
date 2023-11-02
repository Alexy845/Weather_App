using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather_App;

public class WeatherFiveDays
{
    private readonly HttpClient _client;
    private const string ApiKey = "2a2922af3fb2b058c284c0fc51f3348e";
    
    public WeatherFiveDays()
    {
        _client = new HttpClient();
    }
    
    public async Task<ApiClass> GetWeatherFiveDays(string name, string country)
    {
        string requestUrl = $"https://api.openweathermap.org/data/2.5/forecast?q={name},{country}&appid={ApiKey}";
        try
        {
            HttpResponseMessage response =  await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var weather = JsonConvert.DeserializeObject<ApiClass>(await response.Content.ReadAsStringAsync());
            return weather;
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine($"Erreur : {e.Message}");
            return null;
        }
    }
}