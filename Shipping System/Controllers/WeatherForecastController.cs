using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Shipping_System.Controllers
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

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> result = new List<Employee>()
           {
                new Employee() { Id = 6, Name = "ahmed", Email = "ahmed@gmail.com" },
                new Employee() { Id = 7, Name = "ebrahim", Email = "ahmed@gmail.com" },
                new Employee() { Id = 8, Name = "mohamed", Email = "ahmed@gmail.com" },
                new Employee() { Id = 9, Name = "eslam", Email = "ahmed@gmail.com" }
           };

            return result.OrderBy(c => c.Id);
        }
    }
}