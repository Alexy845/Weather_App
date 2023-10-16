using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather_App;

public class WeatherApi
{
    private readonly HttpClient _client;
    private const string ApiKey = "f9c08fb1f9479e2df187b8aed9d4fd42";
    private const string BaseUrl = "http://api.openweathermap.org/data/2.5/forecast?id=524901&appid=";

    public WeatherApi()
    {
        _client = new HttpClient();
    }

    public async Task<API_Class> GetWeatherForecast()
    {
        var response = await _client.GetAsync($"{BaseUrl}{ApiKey}");
        response.EnsureSuccessStatusCode();
        return JsonConvert.DeserializeObject<API_Class>(await response.Content.ReadAsStringAsync());
    }
}