using Microsoft.AspNetCore.Mvc;
using StellantisSupportAPI.Services;

namespace StellantisSupportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly OpenWeatherService _openWeatherService;

        public WeatherController(OpenWeatherService openWeatherService)
        {
            _openWeatherService = openWeatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            try
            {
                var weatherData = await _openWeatherService.GetWeatherByCityAsync(city);
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
