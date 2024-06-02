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
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>()
            {
                new Employee() { Id = 1, Email = "ahmed@gmail.com", Name = "ahmed Test" },
                new Employee() { Id = 2, Email = "ahmed@gmail.com", Name = "ahmed Test" },
                new Employee() { Id = 3, Email = "ahmed@gmail.com", Name = "ahmed Test" },
                new Employee() { Id = 4, Email = "ahmed@gmail.com", Name = "ahmed Test" },
                new Employee() { Id = 5, Email = "ahmed@gmail.com", Name = "ahmed Test" },
            };
            return list;
        }
    }
}
