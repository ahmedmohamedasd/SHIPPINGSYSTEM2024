using Application.Interface;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IAppDbContext _appDbContext;
        public EmployeeService(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Employee> GetEmployees()
        {
            var employees = _appDbContext.Employees.ToList();
            return employees;
        }
    }
}
