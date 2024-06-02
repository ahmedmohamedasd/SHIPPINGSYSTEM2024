using Application.Interface;
using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;

namespace Shipping_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
       
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
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
        public List<EmployeeDto> GetEmployees()
        {
            var employeesList = _employeeService.GetEmployees();
            TinyMapper.Bind<List<Employee>, List<EmployeeDto>>();
            var list= TinyMapper.Map<List<EmployeeDto>>(employeesList);
           // List<Employee> result = new List<Employee>()
           //{
           //     new Employee() { Id = 6, Name = "ahmed", Email = "ahmed@gmail.com" },
           //     new Employee() { Id = 7, Name = "ebrahim", Email = "ahmed@gmail.com" },
           //     new Employee() { Id = 8, Name = "mohamed", Email = "ahmed@gmail.com" },
           //     new Employee() { Id = 9, Name = "eslam", Email = "ahmed@gmail.com" }
           //};
            return list;

            //return result.OrderBy(c => c.Id);
        }
    }
}