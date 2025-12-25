using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class ProductSizeDAO
    {
        private static ProductSizeDAO instance;
        public static ProductSizeDAO Instance => instance ?? (instance = new ProductSizeDAO());
        private ProductSizeDAO() { }

        public List<ProductSizeDTO> GetListSizeByProductId(string productId)
        {
            List<ProductSizeDTO> list = new List<ProductSizeDTO>();
            string query = "SELECT * FROM ProductSize WHERE productId = @pid";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", productId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductSizeDTO
                            {
                                Id = reader["id"].ToString(),
                                ProductId = reader["productId"].ToString(),
                                SizeName = reader["sizeName"].ToString(),
                                PriceAdjustment = Convert.ToDecimal(reader["priceAdjustment"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool InsertProductSize(ProductSizeDTO size)
        {
            string query = "INSERT INTO ProductSize (id, productId, sizeName, priceAdjustment) VALUES (@id, @pid, @name, @price)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(size.Id) ? Guid.NewGuid().ToString() : size.Id);
                    cmd.Parameters.AddWithValue("@pid", size.ProductId);
                    cmd.Parameters.AddWithValue("@name", size.SizeName);
                    cmd.Parameters.AddWithValue("@price", size.PriceAdjustment);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateProductSize(ProductSizeDTO size)
        {
            string query = "UPDATE ProductSize SET sizeName = @name, priceAdjustment = @price WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", size.Id);
                    cmd.Parameters.AddWithValue("@name", size.SizeName);
                    cmd.Parameters.AddWithValue("@price", size.PriceAdjustment);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteProductSize(string id)
        {
            string query = "DELETE FROM ProductSize WHERE id = @id";
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
