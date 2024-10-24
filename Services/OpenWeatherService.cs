using Newtonsoft.Json;

namespace StellantisSupportAPI.Services
{
    public class OpenWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public OpenWeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OpenWeather:ApiKey"];
            _baseUrl = configuration["OpenWeather:BaseUrl"];
        }

        public async Task<WeatherResponse> GetWeatherByCityAsync(string city)
        {
            var url = $"{_baseUrl}weather?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WeatherResponse>(content);
            }
            else
            {
                throw new Exception("Não foi possível obter os dados do tempo.");
            }
        }
    }

    public class WeatherResponse
    {
        public MainData Main { get; set; }
        public List<WeatherData> Weather { get; set; }
        public string Name { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherData
    {
        public string Description { get; set; }
    }
}