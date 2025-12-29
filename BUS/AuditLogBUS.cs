using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class AuditLogBUS
    {
        private static AuditLogBUS instance;
        public static AuditLogBUS Instance => instance ?? (instance = new AuditLogBUS());
        private AuditLogBUS() { }

        public void WriteLog(string userId, string action, string details)
        {
            AuditLogDTO log = new AuditLogDTO { UserId = userId, Action = action, Details = details };
            AuditLogDAO.Instance.InsertLog(log);
        }

        public List<AuditLogDTO> GetAllLogs() => AuditLogDAO.Instance.GetLogs();

        public void ClockIn(string userId)
        {
            WriteLog(userId, "ClockIn", "Chấm công vào ca");
        }

        public void ClockOut(string userId)
        {
            WriteLog(userId, "ClockOut", "Chấm công kết thúc ca");
        }
    }
}
