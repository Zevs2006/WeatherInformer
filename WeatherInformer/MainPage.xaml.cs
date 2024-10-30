using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace WeatherInformer
{
    public partial class MainPage : ContentPage
    {
        private const string ApiKey = "9fc24a92dd289b95469e72ded3670acc";
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric";






        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadWeatherData("Moscow"); // Замените "Moscow" на нужный город
        }

        private async void OnGetWeatherClicked(object sender, EventArgs e)
        {
            // Получаем название города из Entry
            string city = CityEntry.Text ?? "Moscow"; // Устанавливаем значение по умолчанию, если CityEntry пустой
            await LoadWeatherData(city);
        }

        private async Task LoadWeatherData(string city)
        {
            try
            {
                using HttpClient client = new HttpClient();
                string url = string.Format(ApiUrl, city, ApiKey);
                WeatherData weatherData = await client.GetFromJsonAsync<WeatherData>(url);

                // Проверяем на наличие данных
                if (weatherData != null)
                {
                    TemperatureLabel.Text = $"{weatherData.Main.Temp} °C";
                    HumidityLabel.Text = $"{weatherData.Main.Humidity}%";
                    WindSpeedLabel.Text = $"{weatherData.Wind.Speed} м/с";
                    WeatherDescriptionLabel.Text = weatherData.Weather[0].Description; // Доступ к описанию погоды
                }
                else
                {
                    WeatherDescriptionLabel.Text = "Данные не найдены";
                }
            }
            catch (HttpRequestException e)
            {
                WeatherDescriptionLabel.Text = $"Ошибка: {e.Message}";
            }
            catch (Exception e)
            {
                WeatherDescriptionLabel.Text = $"Произошла ошибка: {e.Message}";
            }
        }
    }

    public class WeatherData
    {
        public MainData Main { get; set; } = new MainData();
        public List<WeatherInfo> Weather { get; set; } = new List<WeatherInfo>(); // Изменяем имя класса Weather
        public WindInfo Wind { get; set; } = new WindInfo(); // Убедитесь, что имя Wind не конфликтует

        public class MainData
        {
            public float Temp { get; set; }
            public float Humidity { get; set; }
        }

        public class WeatherInfo // Изменение имени класса Weather
        {
            public string Description { get; set; } = string.Empty;
        }

        public class WindInfo // Изменено имя класса Wind на WindInfo
        {
            public float Speed { get; set; }
        }
    }
}
