using OHIOCF.DAO;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHIOCF.BUS
{
    internal class ReportBUS
    {
        private static ReportBUS instance;
        public static ReportBUS Instance => instance ?? (instance = new ReportBUS());
        private ReportBUS() { }

        public List<ReportDTO> GetRevenue(DateTime from, DateTime to)
        {
            return ReportDAO.Instance.GetRevenueByDate(from, to);
        }
    }
}
