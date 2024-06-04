using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class SystemConstants
    {
        public static class Seeds
        {
            public static class SeedUser
            {
                public static string UserName = "ahmed";
                public static string Email = "ahmed@gmail.com";
                public static string Password = "ahmed@123";
                public static string FullName = "Ahmed Mohamed";
                public static string CardNumber = "44565454";

            }
            public static class SeedAdmin
            {
                public static string UserName = "Admin";
                public static string Email = "Admin@Macber-eg.com";
                public static string Password = "Admin@123";
                public static string FullName = "Aborukba";
                public static string CardNumber = "1111111";

            }
            public static class SeedAdminRole
            {
                public static string Name = "Administrator";
            }

        }

        public static class AuthorizationConstants
        {
            public static class Claims
            {
                public static class Employee
                {
                    public const string GetEmployees = $"{nameof(Employee)}-{nameof(GetEmployees)}";
                }

                public static Dictionary<string ,List<string>> GetClaims()
                {
                    Dictionary<string , List<string>> resultList = new Dictionary<string , List<string>>();
                    var authorizationConstantsType = typeof(AuthorizationConstants.Claims);
                    var listOfClaimsCategories = authorizationConstantsType.GetNestedTypes();

                    foreach(var className in listOfClaimsCategories)
                    {
                        var claimList = new List<string>();
                        foreach(var claimName in className.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
                        {
                            claimList.Add(claimName.GetValue(null)?.ToString() ??string.Empty);
                        }
                        resultList.Add(className.Name, claimList);
                    }
                    return resultList;

                }
            }
           
        }
    }
}
