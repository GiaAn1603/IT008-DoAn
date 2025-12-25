using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class InventoryDAO
    {
        private static InventoryDAO instance;
        public static InventoryDAO Instance => instance ?? (instance = new InventoryDAO());
        private InventoryDAO() { }

        public List<InventoryDTO> GetList()
        {
            List<InventoryDTO> list = new List<InventoryDTO>();
            string query = "SELECT * FROM Inventory";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new InventoryDTO
                            {
                                Id = reader["id"].ToString(),
                                IngredientId = reader["ingredientId"].ToString(),
                                StockQuantity = Convert.ToDouble(reader["stockQuantity"]),
                                LastUpdated = DateTime.Parse(reader["lastUpdated"].ToString()),
                                MinThreshold = Convert.ToDouble(reader["minThreshold"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool UpdateStock(string ingredientId, double quantityChange)
        {
            string query = "UPDATE Inventory SET stockQuantity = stockQuantity + @change, lastUpdated = @time WHERE ingredientId = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ingredientId);
                    cmd.Parameters.AddWithValue("@change", quantityChange);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Insert(InventoryDTO item)
        {
            string query = "INSERT INTO Inventory (id, ingredientId, stockQuantity, lastUpdated, minThreshold) VALUES (@id, @iid, @stock, @time, @min)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@iid", item.IngredientId);
                    cmd.Parameters.AddWithValue("@stock", item.StockQuantity);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@min", item.MinThreshold);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
