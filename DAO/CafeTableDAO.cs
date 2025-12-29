using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class CafeTableDAO
    {
        private static CafeTableDAO instance;
        public static CafeTableDAO Instance => instance ?? (instance = new CafeTableDAO());
        private CafeTableDAO() { }

        public List<CafeTableDTO> GetListTable()
        {
            List<CafeTableDTO> list = new List<CafeTableDTO>();
            string query = "SELECT * FROM CafeTable ORDER BY area, tableName";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new CafeTableDTO
                            {
                                Id = reader["id"].ToString(),
                                TableName = reader["tableName"].ToString(),
                                Status = Convert.ToInt32(reader["status"]),
                                Area = reader["area"] != DBNull.Value ? reader["area"].ToString() : ""
                            });
                        }
                    }
                }
            }
            return list;
        }

        public bool InsertTable(CafeTableDTO table)
        {
            string query = "INSERT INTO CafeTable (id, tableName, status, area) VALUES (@id, @name, @status, @area)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", string.IsNullOrEmpty(table.Id) ? Guid.NewGuid().ToString() : table.Id);
                    cmd.Parameters.AddWithValue("@name", table.TableName);
                    cmd.Parameters.AddWithValue("@status", table.Status);
                    cmd.Parameters.AddWithValue("@area", table.Area);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateTable(CafeTableDTO table)
        {
            string query = "UPDATE CafeTable SET tableName = @name, status = @status, area = @area WHERE id = @id";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", table.Id);
                    cmd.Parameters.AddWithValue("@name", table.TableName);
                    cmd.Parameters.AddWithValue("@status", table.Status);
                    cmd.Parameters.AddWithValue("@area", table.Area);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateTableStatus(string id, int status)
        {
            string query = "UPDATE CafeTable SET status = @status WHERE id = @id";
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

        public bool DeleteTable(string id)
        {
            string query = "DELETE FROM CafeTable WHERE id = @id";
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
