using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather_App;

public class WeatherApi
{
    private readonly HttpClient _client;
    private const string ApiKey = "2a2922af3fb2b058c284c0fc51f3348e";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather?lat={city id}&appid=";
    public List<City1>? AllCity;

    public WeatherApi()
    {
        _client = new HttpClient();
    }

    public bool Ok { get; set; }

    public async void GetCity(string ville)
    {
        ville = ville.Replace(" ", "+");
        string requestUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={ville}&limit=5&appid={ApiKey}";
        try
        {
            HttpResponseMessage response =  await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            AllCity = JsonConvert.DeserializeObject<List<City1>>(await response.Content.ReadAsStringAsync());
            Ok = true;
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine($"Erreur : {e.Message}");
        }
    }

    public async Task<ApiClass?> GetWeatherForecast(float lat, float lon)
    {
        var response = await _client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={ApiKey}");
        if (!response.IsSuccessStatusCode)
            return null;
        response.EnsureSuccessStatusCode();
        return JsonConvert.DeserializeObject<ApiClass>(await response.Content.ReadAsStringAsync());
    }
    
    public class ApiClass
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string Base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int cod { get; set; }
        public int timezone { get; set; }
    }
    

    public class Main
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public float message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}








public class Coord
{
    public float lon { get; set; }
    public float lat { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

public class City
{
    public float id { get; set; }
    public string name { get; set; }
    public Coord coord { get; set; }
    public string country { get; set; }
    public string state { get; set; }
    
}


public class City1
{
    public string name { get; set; }
    public float lat { get; set; }
    public float lon { get; set; }
    public string country { get; set; }
    public string state { get; set; }
}