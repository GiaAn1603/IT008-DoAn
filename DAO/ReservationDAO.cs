using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class ReservationDAO
    {
        private static ReservationDAO instance;
        public static ReservationDAO Instance => instance ?? (instance = new ReservationDAO());
        private ReservationDAO() { }

        public List<ReservationDTO> GetList()
        {
            List<ReservationDTO> list = new List<ReservationDTO>();
            string query = "SELECT * FROM Reservation ORDER BY reservationTime ASC";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ReservationDTO
                            {
                                Id = reader["id"].ToString(),
                                TableId = reader["tableId"].ToString(),
                                CustomerName = reader["customerName"].ToString(),
                                CustomerPhone = reader["customerPhone"].ToString(),
                                ReservationTime = DateTime.Parse(reader["reservationTime"].ToString()),
                                NumberOfPeople = Convert.ToInt32(reader["numberOfPeople"]),
                                Status = Convert.ToInt32(reader["status"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool Insert(ReservationDTO res)
        {
            string query = "INSERT INTO Reservation (id, tableId, customerName, customerPhone, reservationTime, numberOfPeople, status) VALUES (@id, @tid, @name, @phone, @time, @num, @status)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@tid", res.TableId);
                    cmd.Parameters.AddWithValue("@name", res.CustomerName);
                    cmd.Parameters.AddWithValue("@phone", res.CustomerPhone);
                    cmd.Parameters.AddWithValue("@time", res.ReservationTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@num", res.NumberOfPeople);
                    cmd.Parameters.AddWithValue("@status", 0);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateStatus(string id, int status)
        {
            string query = "UPDATE Reservation SET status = @status WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@status", status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
