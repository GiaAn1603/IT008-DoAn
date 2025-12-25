using System;

namespace OHIOCF.DTO
{
    public class ReservationDTO
    {
        public string Id { get; set; }
        public string TableId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime ReservationTime { get; set; }
        public int NumberOfPeople { get; set; }
        public int Status { get; set; }
    }
}
