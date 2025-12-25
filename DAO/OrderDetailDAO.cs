using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
        public static OrderDetailDAO Instance => instance ?? (instance = new OrderDetailDAO());
        private OrderDetailDAO() { }

        public List<OrderDetailDTO> GetListDetailByOrderId(string orderId)
        {
            List<OrderDetailDTO> list = new List<OrderDetailDTO>();
            string query = "SELECT * FROM OrderDetail WHERE orderId = @oid";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", orderId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new OrderDetailDTO
                            {
                                Id = reader["id"].ToString(),
                                OrderId = reader["orderId"].ToString(),
                                ProductId = reader["productId"].ToString(),
                                ProductSizeId = reader["productSizeId"].ToString(),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                PriceAtTime = Convert.ToDecimal(reader["priceAtTime"]),
                                Note = reader["note"] != DBNull.Value ? reader["note"].ToString() : ""
                            });
                        }
                    }
                }
            }
            return list;
        }

        public OrderDetailDTO GetDetailByOrderProductSize(string orderId, string productId, string sizeId)
        {
            string query = "SELECT * FROM OrderDetail WHERE orderId = @oid AND productId = @pid AND productSizeId = @sid";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", orderId);
                    cmd.Parameters.AddWithValue("@pid", productId);
                    cmd.Parameters.AddWithValue("@sid", sizeId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderDetailDTO
                            {
                                Id = reader["id"].ToString(),
                                OrderId = reader["orderId"].ToString(),
                                ProductId = reader["productId"].ToString(),
                                ProductSizeId = reader["productSizeId"].ToString(),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                PriceAtTime = Convert.ToDecimal(reader["priceAtTime"]),
                                Note = reader["note"] != DBNull.Value ? reader["note"].ToString() : ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool InsertOrderDetail(OrderDetailDTO detail)
        {
            string query = "INSERT INTO OrderDetail (id, orderId, productId, productSizeId, quantity, priceAtTime, note) " +
                           "VALUES (@id, @oid, @pid, @sid, @qty, @price, @note)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(detail.Id) ? Guid.NewGuid().ToString() : detail.Id);
                    cmd.Parameters.AddWithValue("@oid", detail.OrderId);
                    cmd.Parameters.AddWithValue("@pid", detail.ProductId);
                    cmd.Parameters.AddWithValue("@sid", detail.ProductSizeId);
                    cmd.Parameters.AddWithValue("@qty", detail.Quantity);
                    cmd.Parameters.AddWithValue("@price", detail.PriceAtTime);
                    cmd.Parameters.AddWithValue("@note", detail.Note ?? "");
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateOrderDetail(OrderDetailDTO detail)
        {
            string query = "UPDATE OrderDetail SET quantity = @qty, note = @note, priceAtTime = @price WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", detail.Id);
                    cmd.Parameters.AddWithValue("@qty", detail.Quantity);
                    cmd.Parameters.AddWithValue("@note", detail.Note ?? "");
                    cmd.Parameters.AddWithValue("@price", detail.PriceAtTime);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteOrderDetail(string id)
        {
            string query = "DELETE FROM OrderDetail WHERE id = @id";
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

        public decimal GetTotalAmountByOrderId(string orderId)
        {
            string query = "SELECT COALESCE(SUM(quantity * priceAtTime), 0) FROM OrderDetail WHERE orderId = @oid";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", orderId);
                    object result = cmd.ExecuteScalar();
                    return Convert.ToDecimal(result);
                }
            }
        }
    }
}
