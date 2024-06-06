using Application.Constants;
using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shipping_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Policy =SystemConstants.AuthorizationConstants.Claims.Employee.GetEmployees)]
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return employees;
        }
    }
}
