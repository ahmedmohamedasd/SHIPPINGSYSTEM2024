using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAppDbContext
    {
        public DbSet<Employee> Employees { get; set; }
        int SaveChanges();
    }
}
