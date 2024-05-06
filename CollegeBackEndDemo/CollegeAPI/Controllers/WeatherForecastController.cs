using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger; // esta es la forma en como debemos usar el Logger en nuetros controllres u otro modulo de nustra app.

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            // Uso de loggers en nuetra aplicacion.
            _logger.LogDebug("Debug Log Level");
            _logger.LogInformation("Inforamtion Log Level");
            _logger.LogWarning("Warning Log Level");
            _logger.LogError("Error Log Level");
            _logger.LogCritical("Critical Log Level");
            _logger.LogTrace("Trace Log Level");
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
