using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace OHIOCF.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        public static CustomerDAO Instance => instance ?? (instance = new CustomerDAO());
        private CustomerDAO() { }

        public List<CustomerDTO> GetListCustomer()
        {
            List<CustomerDTO> list = new List<CustomerDTO>();
            string query = "SELECT * FROM Customer";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CustomerDTO
                            {
                                Id = reader["id"].ToString(),
                                FullName = reader["fullName"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Points = Convert.ToInt32(reader["points"]),
                                Rank = reader["rank"] != DBNull.Value ? reader["rank"].ToString() : "Thành viên"
                            });
                        }
                    }
                }
            }
            return list;
        }

        public CustomerDTO GetCustomerByPhone(string phone)
        {
            string query = "SELECT * FROM Customer WHERE phone = @phone";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerDTO
                            {
                                Id = reader["id"].ToString(),
                                FullName = reader["fullName"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Points = Convert.ToInt32(reader["points"]),
                                Rank = reader["rank"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool InsertCustomer(CustomerDTO c)
        {
            string query = "INSERT INTO Customer (id, fullName, phone, points, rank) VALUES (@id, @name, @phone, @points, @rank)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(c.Id) ? Guid.NewGuid().ToString() : c.Id);
                    cmd.Parameters.AddWithValue("@name", c.FullName);
                    cmd.Parameters.AddWithValue("@phone", c.Phone);
                    cmd.Parameters.AddWithValue("@points", c.Points);
                    cmd.Parameters.AddWithValue("@rank", string.IsNullOrEmpty(c.Rank) ? "Thành viên" : c.Rank);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateCustomer(CustomerDTO c)
        {
            string query = "UPDATE Customer SET fullName = @name, phone = @phone, points = @points, rank = @rank WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", c.Id);
                    cmd.Parameters.AddWithValue("@name", c.FullName);
                    cmd.Parameters.AddWithValue("@phone", c.Phone);
                    cmd.Parameters.AddWithValue("@points", c.Points);
                    cmd.Parameters.AddWithValue("@rank", c.Rank);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdatePoint(string id, int newPoints)
        {
            string query = "UPDATE Customer SET points = @points WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@points", newPoints);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteCustomer(string id)
        {
            string query = "DELETE FROM Customer WHERE id = @id";
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
        public CustomerDTO GetCustomerById(string id)
        {
            string query = "SELECT * FROM Customer WHERE id = @id";

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
                            return new CustomerDTO
                            {
                                Id = reader["id"].ToString(),
                                FullName = reader["fullName"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Points = Convert.ToInt32(reader["points"]),
                                Rank = reader["rank"] != DBNull.Value
                                    ? reader["rank"].ToString()
                                    : "Đồng"
                            };
                        }
                    }
                }
            }
            return null;
        }
        public bool UpdatePointAndRank(string id, int points, string rank)
        {
            string query = "UPDATE Customer SET points = @points, rank = @rank WHERE id = @id";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@points", points);
                    cmd.Parameters.AddWithValue("@rank", rank);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}
