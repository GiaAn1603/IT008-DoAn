using System;

namespace OHIOCF.DTO
{
    public class ScheduleDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Note { get; set; }
    }
}
