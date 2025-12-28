using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHIOCF.DTO
{
    public class ReportDTO
    {
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string StaffName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
