using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHIOCF.DAO
{
    public class ReportDAO
    {
        private static ReportDAO instance;
        public static ReportDAO Instance => instance ?? (instance = new ReportDAO());
        private ReportDAO() { }

        public List<ReportDTO> GetRevenueByDate(DateTime from, DateTime to)
        {
            List<ReportDTO> list = new List<ReportDTO>();

            string query = @"
                SELECT  o.id,
                        o.orderDate,
                        c.fullName AS customerName,
                        u.fullName AS staffName,
                        o.totalAmount
                FROM [Order] o
                LEFT JOIN Customer c ON o.customerId = c.id
                LEFT JOIN User u     ON o.userId = u.id
                WHERE o.orderDate BETWEEN @from AND @to
                AND o.status = 1
                ORDER BY o.orderDate ASC";

            using (SQLiteConnection conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@from", from);
                    cmd.Parameters.AddWithValue("@to", to);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ReportDTO
                            {
                                OrderId = reader["id"].ToString(),
                                OrderDate = Convert.ToDateTime(reader["orderDate"]),
                                CustomerName = reader["customerName"]?.ToString() ?? "Khách lẻ",
                                StaffName = reader["staffName"]?.ToString() ?? "(N/A)",
                                TotalAmount = Convert.ToDecimal(reader["totalAmount"])
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
