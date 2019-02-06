using BlogApp.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    static class ApplicationData
    {
        static string adminRoleType = "admin";
        static string userRoleType = "user";
        public static Role adminRole = new Role { Id = 1, RoleType = adminRoleType };
        public static Role userRole = new Role { Id = 2, RoleType = userRoleType };

        static string adminLogin = "admin";
        static string adminPassword = "admin1";
        public static User adminUser = new User() { Id = 1, Login = adminLogin, Password = adminPassword, RoleId = adminRole.Id };
    }
}
