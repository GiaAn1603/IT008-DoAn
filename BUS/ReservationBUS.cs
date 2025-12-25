using System;
using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class ReservationBUS
    {
        private static ReservationBUS instance;
        public static ReservationBUS Instance => instance ?? (instance = new ReservationBUS());
        private ReservationBUS() { }

        public List<ReservationDTO> GetAllReservations() => ReservationDAO.Instance.GetList();

        public bool CreateReservation(ReservationDTO res)
        {
            if (res.ReservationTime < DateTime.Now) return false;
            return ReservationDAO.Instance.Insert(res);
        }

        public bool CompleteReservation(string id)
        {
            return ReservationDAO.Instance.UpdateStatus(id, 1);
        }

        public bool CancelReservation(string id)
        {
            return ReservationDAO.Instance.UpdateStatus(id, 2);
        }
    }
}
