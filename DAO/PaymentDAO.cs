using System;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class PaymentDAO
    {
        private static PaymentDAO instance;
        public static PaymentDAO Instance => instance ?? (instance = new PaymentDAO());
        private PaymentDAO() { }

        public PaymentDTO GetPaymentByOrderId(string orderId)
        {
            string query = "SELECT * FROM Payment WHERE orderId = @oid";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@oid", orderId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PaymentDTO
                            {
                                Id = reader["id"].ToString(),
                                OrderId = reader["orderId"].ToString(),
                                PaymentMethod = reader["paymentMethod"].ToString(),
                                PaymentDate = DateTime.Parse(reader["paymentDate"].ToString()),
                                AmountPaid = Convert.ToDecimal(reader["amountPaid"])
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool InsertPayment(PaymentDTO pay)
        {
            string query = "INSERT INTO Payment (id, orderId, paymentMethod, paymentDate, amountPaid) VALUES (@id, @oid, @method, @date, @amount)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(pay.Id) ? Guid.NewGuid().ToString() : pay.Id);
                    cmd.Parameters.AddWithValue("@oid", pay.OrderId);
                    cmd.Parameters.AddWithValue("@method", pay.PaymentMethod);
                    cmd.Parameters.AddWithValue("@date", pay.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@amount", pay.AmountPaid);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
