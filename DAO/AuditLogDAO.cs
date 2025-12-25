using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class AuditLogDAO
    {
        private static AuditLogDAO instance;
        public static AuditLogDAO Instance => instance ?? (instance = new AuditLogDAO());
        private AuditLogDAO() { }

        public bool InsertLog(AuditLogDTO log)
        {
            string query = "INSERT INTO AuditLog (id, userId, action, logTime, details) VALUES (@id, @userId, @action, @time, @details)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@userId", log.UserId);
                    cmd.Parameters.AddWithValue("@action", log.Action);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@details", log.Details);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<AuditLogDTO> GetLogs()
        {
            List<AuditLogDTO> list = new List<AuditLogDTO>();
            string query = "SELECT * FROM AuditLog ORDER BY logTime DESC";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new AuditLogDTO
                            {
                                Id = reader["id"].ToString(),
                                UserId = reader["userId"].ToString(),
                                Action = reader["action"].ToString(),
                                LogTime = DateTime.Parse(reader["logTime"].ToString()),
                                Details = reader["details"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}
