using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class ProductIngredientDAO
    {
        private static ProductIngredientDAO instance;
        public static ProductIngredientDAO Instance => instance ?? (instance = new ProductIngredientDAO());
        private ProductIngredientDAO() { }

        public List<ProductIngredientDTO> GetRecipeByProductSize(string sizeId)
        {
            List<ProductIngredientDTO> list = new List<ProductIngredientDTO>();
            string query = "SELECT * FROM ProductIngredient WHERE productSizeId = @sid";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", sizeId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductIngredientDTO
                            {
                                Id = reader["id"].ToString(),
                                ProductSizeId = reader["productSizeId"].ToString(),
                                IngredientId = reader["ingredientId"].ToString(),
                                RequiredQuantity = Convert.ToDouble(reader["requiredQuantity"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool Insert(ProductIngredientDTO item)
        {
            string query = "INSERT INTO ProductIngredient (id, productSizeId, ingredientId, requiredQuantity) VALUES (@id, @sid, @iid, @qty)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@sid", item.ProductSizeId);
                    cmd.Parameters.AddWithValue("@iid", item.IngredientId);
                    cmd.Parameters.AddWithValue("@qty", item.RequiredQuantity);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM ProductIngredient WHERE id = @id";
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
