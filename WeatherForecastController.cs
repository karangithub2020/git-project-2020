using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessComponent.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NUnitSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        ILogin _login;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILogin login)
        {
            _logger = logger;
            _login = login;
        }

        public WeatherForecastController(ILogin login)
        {
            // _logger = logger;
            _login = login;
        }
        public WeatherForecastController()
        {

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            if (_login.Login("ak1", "kumar"))
            {
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid user");
            }
        }
    }
}
