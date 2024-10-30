//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;

//public class WeatherApiClient
//{
//    private readonly HttpClient _httpClient;
//    private const string ApiKey = "YOUR_API_KEY"; // Вставьте свой API-ключ OpenWeatherMap

//    public WeatherApiClient()
//    {
//        _httpClient = new HttpClient();
//    }

//    public async Task<WeatherData> GetWeatherAsync(string cityName)
//    {
//        var response = await _httpClient.GetFromJsonAsync<WeatherData>($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={ApiKey}&units=metric");
//        return response;
//    }
//}
