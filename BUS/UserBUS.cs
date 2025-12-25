using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class UserBUS
    {
        private static UserBUS instance;

        public static UserBUS Instance
        {
            get { if (instance == null) instance = new UserBUS(); return instance; }
            private set { instance = value; }
        }

        private UserBUS() { }

        private string GetMD5(string input)
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

        public UserDTO Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            string passwordHash = GetMD5(password);
            return UserDAO.Instance.Login(username, passwordHash);
        }

        public List<UserDTO> GetListUser()
        {
            return UserDAO.Instance.GetListUser();
        }

        public bool InsertUser(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = GetMD5(user.Password);
            }
            return UserDAO.Instance.InsertUser(user);
        }

        public bool UpdateUser(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.Password))
            {
                user.Password = GetMD5(user.Password);
            }
            return UserDAO.Instance.UpdateUser(user);
        }

        public bool DeleteUser(string currentUserId, string targetUserId)
        {
            if (currentUserId == targetUserId) return false;
            return UserDAO.Instance.DeleteUser(targetUserId);
        }
    }
}
