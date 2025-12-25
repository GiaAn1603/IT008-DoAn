using System;

namespace OHIOCF.DTO
{
    public class AuditLogDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public DateTime LogTime { get; set; }
        public string Details { get; set; }
    }
}
