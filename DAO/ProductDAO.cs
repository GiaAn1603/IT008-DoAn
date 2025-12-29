using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;
        public static ProductDAO Instance => instance ?? (instance = new ProductDAO());
        private ProductDAO() { }

        public ProductDTO GetProductById(string id)
        {
            ProductDTO product = null;
            string query = "SELECT * FROM Product WHERE id = @id";

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
                            product = new ProductDTO
                            {
                                Id = reader["id"].ToString(),
                                CategoryId = reader["categoryId"].ToString(),
                                Name = reader["name"].ToString(),
                                BasePrice = Convert.ToDecimal(reader["basePrice"]),
                                Image = reader["image"] != DBNull.Value ? reader["image"].ToString() : "",
                                IsAvailable = Convert.ToInt32(reader["isAvailable"]) == 1
                            };
                        }
                    }
                }
            }
            return product;
        }

        public List<ProductDTO> GetProductsByCategoryId(string catId)
        {
            List<ProductDTO> list = new List<ProductDTO>();

            string query = (string.IsNullOrEmpty(catId) || catId == "All")
                ? "SELECT * FROM Product"
                : "SELECT * FROM Product WHERE categoryId = @catId";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(catId) && catId != "All")
                        cmd.Parameters.AddWithValue("@catId", catId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductDTO
                            {
                                Id = reader["id"].ToString(),
                                CategoryId = reader["categoryId"].ToString(),
                                Name = reader["name"].ToString(),
                                BasePrice = Convert.ToDecimal(reader["basePrice"]),
                                Image = reader["image"] != DBNull.Value ? reader["image"].ToString() : "",
                                IsAvailable = Convert.ToInt32(reader["isAvailable"]) == 1
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<ProductDTO> SearchProductByName(string name)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string query = "SELECT * FROM Product WHERE name LIKE @name";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductDTO
                            {
                                Id = reader["id"].ToString(),
                                CategoryId = reader["categoryId"].ToString(),
                                Name = reader["name"].ToString(),
                                BasePrice = Convert.ToDecimal(reader["basePrice"]),
                                Image = reader["image"] != DBNull.Value ? reader["image"].ToString() : "",
                                IsAvailable = Convert.ToInt32(reader["isAvailable"]) == 1
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool InsertProduct(ProductDTO p)
        {
            string query = "INSERT INTO Product (id, categoryId, name, basePrice, image, isAvailable) VALUES (@id, @catId, @name, @price, @img, @avai)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(p.Id) ? Guid.NewGuid().ToString() : p.Id);
                    cmd.Parameters.AddWithValue("@catId", p.CategoryId);
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@price", p.BasePrice);
                    cmd.Parameters.AddWithValue("@img", p.Image ?? "");
                    cmd.Parameters.AddWithValue("@avai", p.IsAvailable ? 1 : 0);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateProduct(ProductDTO p)
        {
            string query = "UPDATE Product SET categoryId = @catId, name = @name, basePrice = @price, image = @img, isAvailable = @avai WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", p.Id);
                    cmd.Parameters.AddWithValue("@catId", p.CategoryId);
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    cmd.Parameters.AddWithValue("@price", p.BasePrice);
                    cmd.Parameters.AddWithValue("@img", p.Image ?? "");
                    cmd.Parameters.AddWithValue("@avai", p.IsAvailable ? 1 : 0);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteProduct(string id)
        {
            string query = "DELETE FROM Product WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }
        public bool ExistsByName(string productName)
        {
            string query = "SELECT COUNT(*) FROM Product WHERE name = @name";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", productName.Trim());
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
