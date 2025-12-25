using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF
{
    public static class DataSeeder
    {
        private static string GetMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static void Seed()
        {
            string adminRoleId = "";
            var roles = RoleDAO.Instance.GetListRole();

            var adminRole = roles.FirstOrDefault(r => r.RoleName == "Admin");
            if (adminRole == null)
            {
                RoleDAO.Instance.InsertRole("Admin");
                adminRoleId = RoleDAO.Instance.GetListRole().First(r => r.RoleName == "Admin").Id;
            }
            else
            {
                adminRoleId = adminRole.Id;
            }

            var staffRole = roles.FirstOrDefault(r => r.RoleName == "Staff");
            if (staffRole == null)
            {
                RoleDAO.Instance.InsertRole("Staff");
            }

            var users = UserDAO.Instance.GetListUser();
            bool adminExists = users.Any(u => u.Username == "admin");

            if (!adminExists)
            {
                UserDTO rootUser = new UserDTO
                {
                    Id = Guid.NewGuid().ToString(),
                    RoleId = adminRoleId,
                    Username = "admin",
                    Password = GetMD5("123"),
                    FullName = "Administrator",
                    IsActive = true
                };

                UserDAO.Instance.InsertUser(rootUser);
            }
        }
    }
}
