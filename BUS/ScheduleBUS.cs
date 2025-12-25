using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class ScheduleBUS
    {
        private static ScheduleBUS instance;
        public static ScheduleBUS Instance => instance ?? (instance = new ScheduleBUS());
        private ScheduleBUS() { }

        public bool CreateSchedule(ScheduleDTO s)
        {
            if (s.EndTime <= s.StartTime) return false;

            if (ScheduleDAO.Instance.CheckOverlap(s.UserId, s.StartTime, s.EndTime))
            {
                return false;
            }

            return ScheduleDAO.Instance.AddSchedule(s);
        }

        public bool EditSchedule(ScheduleDTO s)
        {
            if (s.EndTime <= s.StartTime) return false;

            if (ScheduleDAO.Instance.CheckOverlap(s.UserId, s.StartTime, s.EndTime, s.Id))
            {
                return false;
            }

            return ScheduleDAO.Instance.UpdateSchedule(s);
        }

        public List<ScheduleDTO> GetAllSchedules()
        {
            return ScheduleDAO.Instance.GetAllSchedules();
        }

        public List<ScheduleDTO> GetUserSchedules(string userId) => ScheduleDAO.Instance.GetSchedulesByUserId(userId);

        public bool RemoveSchedule(string id) => ScheduleDAO.Instance.DeleteSchedule(id);
    }
}
