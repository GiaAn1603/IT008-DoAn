using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class RoleDAO
    {
        private static RoleDAO instance;
        public static RoleDAO Instance
        {
            get { if (instance == null) instance = new RoleDAO(); return instance; }
            private set { instance = value; }
        }

        private RoleDAO() { }

        public List<RoleDTO> GetListRole()
        {
            List<RoleDTO> list = new List<RoleDTO>();
            string query = "SELECT * FROM Role";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new RoleDTO
                            {
                                Id = reader["id"].ToString(),
                                RoleName = reader["roleName"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public RoleDTO GetRoleById(string id)
        {
            string query = "SELECT * FROM Role WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RoleDTO
                            {
                                Id = reader["id"].ToString(),
                                RoleName = reader["roleName"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool InsertRole(string roleName)
        {
            string query = "INSERT INTO Role (id, roleName) VALUES (@id, @name)";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@name", roleName);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateRole(string id, string newName)
        {
            string query = "UPDATE Role SET roleName = @name WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", newName);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteRole(string id)
        {
            string query = "DELETE FROM Role WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SQLiteException)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
