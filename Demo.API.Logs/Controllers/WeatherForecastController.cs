using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Logs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get()
        {

            try
            {
                _logger.LogInformation($"Time : {DateTime.Now}; Executing endpoint GetWeatherForecast");

                throw new ArgumentException("arguement Exeption dlc");

                //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                //    {
                //        Date = DateTime.Now.AddDays(index),
                //        TemperatureC = Random.Shared.Next(-20, 55),
                //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                //    })
                //.ToArray();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"{DateTime.Now} Error{ex.Message}");
                return Problem(ex.Message);

            }

        }
    }
}