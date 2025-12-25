using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class UserDAO
    {
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return instance; }
            private set { instance = value; }
        }

        private UserDAO() { }

        public UserDTO Login(string username, string password)
        {
            string query = "SELECT * FROM User WHERE username = @user AND password = @pass AND isActive = 1";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserDTO
                            {
                                Id = reader["id"].ToString(),
                                RoleId = reader["roleId"].ToString(),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                FullName = reader["fullName"].ToString(),
                                IsActive = Convert.ToBoolean(reader["isActive"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<UserDTO> GetListUser()
        {
            List<UserDTO> list = new List<UserDTO>();
            string query = "SELECT * FROM User WHERE isActive = 1";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new UserDTO
                            {
                                Id = reader["id"].ToString(),
                                RoleId = reader["roleId"].ToString(),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                FullName = reader["fullName"].ToString(),
                                IsActive = Convert.ToBoolean(reader["isActive"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool InsertUser(UserDTO user)
        {
            string query = "INSERT INTO User (id, roleId, username, password, fullName, isActive) VALUES (@id, @roleId, @user, @pass, @name, @active)";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(user.Id) ? Guid.NewGuid().ToString() : user.Id);
                    cmd.Parameters.AddWithValue("@roleId", user.RoleId);
                    cmd.Parameters.AddWithValue("@user", user.Username);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@name", user.FullName);
                    cmd.Parameters.AddWithValue("@active", user.IsActive ? 1 : 0);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateUser(UserDTO user)
        {
            string query;
            if (string.IsNullOrEmpty(user.Password))
            {
                query = "UPDATE User SET roleId = @roleId, fullName = @name, isActive = @active WHERE id = @id";
            }
            else
            {
                query = "UPDATE User SET roleId = @roleId, password = @pass, fullName = @name, isActive = @active WHERE id = @id";
            }

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", user.Id);
                    cmd.Parameters.AddWithValue("@roleId", user.RoleId);
                    cmd.Parameters.AddWithValue("@name", user.FullName);
                    cmd.Parameters.AddWithValue("@active", user.IsActive ? 1 : 0);

                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        cmd.Parameters.AddWithValue("@pass", user.Password);
                    }

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteUser(string id)
        {
            string query = "UPDATE User SET isActive = 0 WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
