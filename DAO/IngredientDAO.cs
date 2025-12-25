using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class IngredientDAO
    {
        private static IngredientDAO instance;
        public static IngredientDAO Instance => instance ?? (instance = new IngredientDAO());
        private IngredientDAO() { }

        public List<IngredientDTO> GetList()
        {
            List<IngredientDTO> list = new List<IngredientDTO>();
            string query = "SELECT * FROM Ingredient";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new IngredientDTO
                            {
                                Id = reader["id"].ToString(),
                                Name = reader["name"].ToString(),
                                Unit = reader["unit"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool Insert(IngredientDTO item)
        {
            string query = "INSERT INTO Ingredient (id, name, unit) VALUES (@id, @name, @unit)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(item.Id) ? Guid.NewGuid().ToString() : item.Id);
                    cmd.Parameters.AddWithValue("@name", item.Name);
                    cmd.Parameters.AddWithValue("@unit", item.Unit);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(IngredientDTO item)
        {
            string query = "UPDATE Ingredient SET name = @name, unit = @unit WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@name", item.Name);
                    cmd.Parameters.AddWithValue("@unit", item.Unit);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM Ingredient WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try { return cmd.ExecuteNonQuery() > 0; } catch { return false; }
                }
            }
        }
    }
}
