using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class ScheduleDAO
    {
        private static ScheduleDAO instance;
        public static ScheduleDAO Instance => instance ?? (instance = new ScheduleDAO());
        private ScheduleDAO() { }

        public bool AddSchedule(ScheduleDTO s)
        {
            string query = "INSERT INTO Schedule (id, userId, startTime, endTime, note) VALUES (@id, @uId, @start, @end, @note)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@uId", s.UserId);
                    cmd.Parameters.AddWithValue("@start", s.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@end", s.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@note", s.Note);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<ScheduleDTO> GetSchedulesByUserId(string userId)
        {
            List<ScheduleDTO> list = new List<ScheduleDTO>();
            string query = "SELECT * FROM Schedule WHERE userId = @uId ORDER BY startTime ASC";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uId", userId);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ScheduleDTO
                            {
                                Id = reader["id"].ToString(),
                                UserId = reader["userId"].ToString(),
                                StartTime = DateTime.Parse(reader["startTime"].ToString()),
                                EndTime = DateTime.Parse(reader["endTime"].ToString()),
                                Note = reader["note"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool DeleteSchedule(string id)
        {
            string query = "DELETE FROM Schedule WHERE id = @id";
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

        public bool UpdateSchedule(ScheduleDTO s)
        {
            string query = "UPDATE Schedule SET startTime = @start, endTime = @end, note = @note WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", s.Id);
                    cmd.Parameters.AddWithValue("@start", s.StartTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@end", s.EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@note", s.Note);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<ScheduleDTO> GetAllSchedules()
        {
            List<ScheduleDTO> list = new List<ScheduleDTO>();
            string query = "SELECT * FROM Schedule ORDER BY startTime DESC";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ScheduleDTO
                            {
                                Id = reader["id"].ToString(),
                                UserId = reader["userId"].ToString(),
                                StartTime = DateTime.Parse(reader["startTime"].ToString()),
                                EndTime = DateTime.Parse(reader["endTime"].ToString()),
                                Note = reader["note"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool CheckOverlap(string userId, DateTime start, DateTime end, string excludeScheduleId = null)
        {
            string query = "SELECT COUNT(*) FROM Schedule WHERE userId = @uid AND (@newStart < endTime AND @newEnd > startTime)";

            if (!string.IsNullOrEmpty(excludeScheduleId))
            {
                query += " AND id != @excludeId";
            }

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@newStart", start.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@newEnd", end.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (!string.IsNullOrEmpty(excludeScheduleId))
                        cmd.Parameters.AddWithValue("@excludeId", excludeScheduleId);

                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
