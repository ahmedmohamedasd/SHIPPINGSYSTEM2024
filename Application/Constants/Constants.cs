using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class Constants
    {
        public static class Seeds
        {
            public static class SeedUser
            {
                public static string UserName = "ahmed";
                public static string Email = "ahmed@gmail.com";
                public static string Password = "ahmed@123";
            }
            public static class SeedAdmin
            {
                public static string UserName = "Admin";
                public static string Email = "Admin@Macber-eg.com";
                public static string Password = "Admin@123";
            }
            public static class SeedAdminRole
            {
                public static string Name = "Administrator";
            }

        }

        public static class AuthorizationConstants
        {
            public static class Employee
            {
                public const string GetEmployees = $"{nameof(Employee)}-{nameof(GetEmployees)}";
            }
        }
    }
}
