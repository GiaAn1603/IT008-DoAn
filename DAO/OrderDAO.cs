using System;
using System.Data.SQLite;
using DocumentFormat.OpenXml.Office.Y2022.FeaturePropertyBag;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        public static OrderDAO Instance => instance ?? (instance = new OrderDAO());
        private OrderDAO() { }

        public OrderDTO GetUnpaidOrderByTable(string tableId)
        {
            string query = "SELECT * FROM [Order] WHERE tableId = @tid AND status = 0";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tid", tableId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderDTO
                            {
                                Id = reader["id"].ToString(),
                                TableId = reader["tableId"].ToString(),
                                UserId = reader["userId"].ToString(),
                                CustomerId = reader["customerId"] != DBNull.Value ? reader["customerId"].ToString() : null,
                                PromotionId = reader["promotionId"] != DBNull.Value ? reader["promotionId"].ToString() : null,
                                OrderDate = DateTime.Parse(reader["orderDate"].ToString()),
                                TotalAmount = Convert.ToDecimal(reader["totalAmount"]),
                                Status = Convert.ToInt32(reader["status"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool InsertOrder(OrderDTO order)
        {
            string query = "INSERT INTO [Order] (id, tableId, userId, customerId, promotionId, orderDate, totalAmount, status) " +
                           "VALUES (@id, @tid, @uid, @cid, @pid, @date, @total, @status)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(order.Id) ? Guid.NewGuid().ToString() : order.Id);
                    cmd.Parameters.AddWithValue("@tid", order.TableId);
                    cmd.Parameters.AddWithValue("@uid", order.UserId);
                    cmd.Parameters.AddWithValue("@cid", (object)order.CustomerId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pid", (object)order.PromotionId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@total", order.TotalAmount);
                    cmd.Parameters.AddWithValue("@status", 0);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateOrderTotal(string id, decimal total)
        {
            string query = "UPDATE [Order] SET totalAmount = @total WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@total", total);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateOrderInfo(string orderId, decimal totalAmount, string promotionId, string customerId)
        {
            string query = @"UPDATE [Order] 
                     SET totalAmount = @total,
                         promotionId = @promo,
                         customerId = @cid
                     WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    cmd.Parameters.AddWithValue("@total", totalAmount);
                    cmd.Parameters.AddWithValue("@promo", (object)promotionId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cid", (object)customerId ?? DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public bool CheckoutOrder(string id, decimal finalTotal, string customerId = null, string promotionId = null)
        {
            string query = "UPDATE [Order] SET status = 1, totalAmount = @total, customerId = @cid, promotionId = @pid WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@total", finalTotal);
                    cmd.Parameters.AddWithValue("@cid", (object)customerId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@pid", (object)promotionId ?? DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteOrder(string id)
        {
            string query = "DELETE FROM [Order] WHERE id = @id";
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

        public bool UpdateOrderPromotion(string orderId, string promotionId)
        {
            string query = "UPDATE [Order] SET promotionId = @promoId WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);

                    if (string.IsNullOrEmpty(promotionId))
                        cmd.Parameters.AddWithValue("@promoId", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@promoId", promotionId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public OrderDTO GetOrderById(string orderId)
        {
            string query = "SELECT * FROM [Order] WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderDTO
                            {
                                Id = reader["id"].ToString(),
                                TableId = reader["tableId"].ToString(),
                                UserId = reader["userId"].ToString(),
                                CustomerId = reader["customerId"] != DBNull.Value ? reader["customerId"].ToString() : null,
                                PromotionId = reader["promotionId"] != DBNull.Value ? reader["promotionId"].ToString() : null,
                                OrderDate = DateTime.Parse(reader["orderDate"].ToString()),
                                TotalAmount = Convert.ToDecimal(reader["totalAmount"]),
                                Status = Convert.ToInt32(reader["status"])
                            };
                        }
                    }
                }
            }
            return null;
        }
        public int GetInvoiceCount()
        {
            string query = "SELECT COUNT(*) FROM [Order] WHERE status = 1";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        public decimal GetTotalRevenue()
        {
            string query = "SELECT IFNULL(SUM(totalAmount), 0) FROM [Order] WHERE status = 1";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        public decimal GetTodayRevenue()
        {
            string query = @"
        SELECT IFNULL(SUM(totalAmount), 0)
        FROM [Order]
        WHERE status = 1
          AND DATE(orderDate) = DATE('now')
    ";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }


    }
}
