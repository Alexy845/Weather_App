using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather_App.API;

public class WeatherFiveDays
{
    private readonly HttpClient _client;
    private static readonly string? ApiKey = ConfigurationManager.AppSettings["ApiKey"];

    public WeatherFiveDays()
    {
        _client = new HttpClient();
    }

    public async Task<Weather5Days?> GetWeatherFiveDays(string? name, string country)
    {
        string requestUrl =
            $"https://api.openweathermap.org/data/2.5/forecast?q={name},{country}&lang={Lang.Lang.LangToCode(MainWindow.country.ToString())}&appid={ApiKey}";
        try
        {
            HttpResponseMessage response = await _client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var weather = JsonConvert.DeserializeObject<Weather5Days>(await response.Content.ReadAsStringAsync());
            return weather;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erreur : {e.Message}");
            return null;
        }
    }


    public class Weather5Days
    {
        public string? cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<Day>? list { get; set; }

        public class Day
        {
            public int dt { get; set; }
            public Main? main { get; set; }

            public class Main
            {
                public float temp { get; set; }
                public float feelsLike { get; set; }
                public float tempMin { get; set; }
                public float tempMax { get; set; }
                public int pressure { get; set; }
                public int seaLevel { get; set; }
                public int grndLevel { get; set; }
                public int humidity { get; set; }
                public float tempKf { get; set; }
            }

            public List<Weather>? weather { get; set; }

            public class Weather
            {
                public int id { get; set; }
                public string? main { get; set; }
                public string? description { get; set; }
                public string? icon { get; set; }
            }

            public Clouds? clouds { get; set; }

            public class Clouds
            {
                public string? all { get; set; }
            }

            public Wind? wind { get; set; }

            public class Wind
            {
                public float speed { get; set; }
                public float deg { get; set; }
                public float gust { get; set; }
            }

            public float visibility { get; set; }
            public float pop { get; set; }
            public Rain? rain { get; set; }

            public class Rain
            {
                public float _1h { get; set; }
                public float _3h { get; set; }
            }

            public Snow? snow { get; set; }

            public class Snow
            {
                public float _1h { get; set; }
                public float _3h { get; set; }
            }

            public Sys? sys { get; set; }

            public class Sys
            {
                public string? pod { get; set; }
            }

            public string? dtTxt { get; set; }
        }

        public City? city { get; set; }

        public class City
        {
            public int id { get; set; }
            public string? name { get; set; }
            public Coord? coord { get; set; }

            public class Coord
            {
                public float lat { get; set; }
                public float lon { get; set; }
            }

            public string? country { get; set; }
            public int population { get; set; }
            public int timezone { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }
    }
}