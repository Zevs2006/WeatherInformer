//using System.Collections.Generic;
//using System.IO;
//using System.Text.Json;

//public class WeatherCache
//{
//    private readonly string _cacheFilePath;

//    public WeatherCache()
//    {
//        _cacheFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "weatherCache.json");
//    }

//    public void Save(string cityName, WeatherData weatherData)
//    {
//        var cache = LoadCache();
//        cache[cityName] = weatherData;
//        File.WriteAllText(_cacheFilePath, JsonSerializer.Serialize(cache));
//    }

//    public WeatherData Get(string cityName)
//    {
//        var cache = LoadCache();
//        return cache.TryGetValue(cityName, out var weatherData) ? weatherData : null;
//    }

//    private Dictionary<string, WeatherData> LoadCache()
//    {
//        if (!File.Exists(_cacheFilePath))
//            return new Dictionary<string, WeatherData>();

//        var json = File.ReadAllText(_cacheFilePath);
//        return JsonSerializer.Deserialize<Dictionary<string, WeatherData>>(json);
//    }
//}
