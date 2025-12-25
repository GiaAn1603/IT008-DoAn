using System;
using System.Collections.Generic;
using System.Data.SQLite;
using OHIOCF.DTO;

namespace OHIOCF.DAO
{
    public class PromotionDAO
    {
        private static PromotionDAO instance;
        public static PromotionDAO Instance => instance ?? (instance = new PromotionDAO());
        private PromotionDAO() { }

        public List<PromotionDTO> GetList()
        {
            List<PromotionDTO> list = new List<PromotionDTO>();
            string query = "SELECT * FROM Promotion";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PromotionDTO
                            {
                                Id = reader["id"].ToString(),
                                Code = reader["code"].ToString(),
                                DiscountValue = Convert.ToDecimal(reader["discountValue"]),
                                DiscountType = Convert.ToInt32(reader["discountType"]),
                                StartDate = DateTime.Parse(reader["startDate"].ToString()),
                                EndDate = DateTime.Parse(reader["endDate"].ToString())
                            });
                        }
                    }
                }
            }
            return list;
        }

        public PromotionDTO GetByCode(string code)
        {
            string query = "SELECT * FROM Promotion WHERE code = @code";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PromotionDTO
                            {
                                Id = reader["id"].ToString(),
                                Code = reader["code"].ToString(),
                                DiscountValue = Convert.ToDecimal(reader["discountValue"]),
                                DiscountType = Convert.ToInt32(reader["discountType"]),
                                StartDate = DateTime.Parse(reader["startDate"].ToString()),
                                EndDate = DateTime.Parse(reader["endDate"].ToString())
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool Insert(PromotionDTO p)
        {
            string query = "INSERT INTO Promotion (id, code, discountValue, discountType, startDate, endDate) VALUES (@id, @code, @val, @type, @start, @end)";
            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cmd.Parameters.AddWithValue("@code", p.Code);
                    cmd.Parameters.AddWithValue("@val", p.DiscountValue);
                    cmd.Parameters.AddWithValue("@type", p.DiscountType);
                    cmd.Parameters.AddWithValue("@start", p.StartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@end", p.EndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(string id)
        {
            string query = "DELETE FROM Promotion WHERE id = @id";
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
    }
}
