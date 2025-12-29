using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance => instance ?? (instance = new CategoryDAO());
        private CategoryDAO() { }

        public List<CategoryDTO> GetListCategory()
        {
            List<CategoryDTO> list = new List<CategoryDTO>();
            string query = "SELECT * FROM Category";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CategoryDTO
                            {
                                Id = reader["id"].ToString(),
                                Name = reader["name"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public CategoryDTO GetCategoryById(string id)
        {
            string query = "SELECT * FROM Category WHERE id = @id";
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
                            return new CategoryDTO
                            {
                                Id = reader["id"].ToString(),
                                Name = reader["name"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool InsertCategory(CategoryDTO cat)
        {
            string query = "INSERT INTO Category (id, name) VALUES (@id, @name)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(cat.Id) ? Guid.NewGuid().ToString() : cat.Id);
                    cmd.Parameters.AddWithValue("@name", cat.Name);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateCategory(CategoryDTO cat)
        {
            string query = "UPDATE Category SET name = @name WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cat.Id);
                    cmd.Parameters.AddWithValue("@name", cat.Name);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteCategory(string id)
        {
            string query = "DELETE FROM Category WHERE id = @id";
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
