using OHIOCF.DAO;
using OHIOCF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public DateTime GetMondayOfWeek(DateTime date)
        {
            DateTime dateOnly = date.Date;
            int daysFromMonday = ((int)dateOnly.DayOfWeek - 1 + 7) % 7;
            return dateOnly.AddDays(-daysFromMonday);
        }

        /// Lấy tất cả lịch làm việc trong tuần
        public List<ScheduleDTO> GetWeekSchedules(DateTime monday)
        {
            var allSchedules = ScheduleDAO.Instance.GetAllSchedules();
            if (allSchedules == null) return new List<ScheduleDTO>();

            DateTime sunday = monday.AddDays(6);

            return allSchedules
                .Where(s => s.StartTime.Date >= monday && s.StartTime.Date <= sunday)
                .ToList();
        }

        /// Xác định ca làm việc 
        public int GetShiftIndex(int hour)
        {
            if (hour >= 5 && hour < 12) return 0;   // Ca sáng
            if (hour >= 12 && hour < 17) return 1;  // Ca chiều
            if (hour >= 17 && hour < 22) return 2;  // Ca tối
            return -1;
        }

        /// Lấy thời gian bắt đầu và kết thúc của ca làm việc
        public (DateTime startTime, DateTime endTime) GetShiftTime(DateTime date, int shiftIndex)
        {
            DateTime startTime, endTime;

            switch (shiftIndex)
            {
                case 0:
                    startTime = date.AddHours(5);
                    endTime = date.AddHours(12);
                    break;
                case 1:
                    startTime = date.AddHours(12);
                    endTime = date.AddHours(17);
                    break;
                case 2:
                    startTime = date.AddHours(17);
                    endTime = date.AddHours(22);
                    break;
                default:
                    throw new ArgumentException("Shift index không hợp lệ. Phải từ 0-2");
            }

            return (startTime, endTime);
        }

        //Lưu 
        public (int successCount, int failCount, List<string> errors) SaveWeekSchedules(
            DateTime monday,
            List<ScheduleDTO> newSchedules)
        {
            int successCount = 0;
            int failCount = 0;
            List<string> errors = new List<string>();

            try
            {
                // Bước 1: Xóa tất cả lịch cũ của tuần
                var oldSchedules = GetWeekSchedules(monday);
                foreach (var schedule in oldSchedules)
                {
                    if (!RemoveSchedule(schedule.Id))
                    {
                        errors.Add($"Không thể xóa lịch cũ ID: {schedule.Id}");
                    }
                }

                // Bước 2: Thêm lịch mới
                foreach (var schedule in newSchedules)
                {
                    if (CreateSchedule(schedule))
                    {
                        successCount++;
                    }
                    else
                    {
                        failCount++;
                        errors.Add($"Không thể tạo lịch từ {schedule.StartTime:dd/MM HH:mm} đến {schedule.EndTime:HH:mm}");
                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add($"Lỗi hệ thống: {ex.Message}");
                failCount++;
            }

            return (successCount, failCount, errors);
        }

        /// Lấy lịch làm việc theo tuần và nhóm theo ngày + ca
        public Dictionary<DateTime, Dictionary<int, List<ScheduleDTO>>> GetWeekSchedulesGrouped(DateTime monday)
        {
            var weekSchedules = GetWeekSchedules(monday);
            var result = new Dictionary<DateTime, Dictionary<int, List<ScheduleDTO>>>();

            // Khởi tạo dictionary cho 7 ngày
            for (int i = 0; i < 7; i++)
            {
                DateTime date = monday.AddDays(i);
                result[date] = new Dictionary<int, List<ScheduleDTO>>
                {
                    { 0, new List<ScheduleDTO>() }, // Ca sáng
                    { 1, new List<ScheduleDTO>() }, // Ca chiều
                    { 2, new List<ScheduleDTO>() }  // Ca tối
                };
            }

            // Phân loại lịch vào các ca
            foreach (var schedule in weekSchedules)
            {
                int shiftIndex = GetShiftIndex(schedule.StartTime.Hour);
                if (shiftIndex == -1) continue;

                DateTime date = schedule.StartTime.Date;
                if (result.ContainsKey(date))
                {
                    result[date][shiftIndex].Add(schedule);
                }
            }

            return result;
        }

    }
}

