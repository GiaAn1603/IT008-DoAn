using System;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class PaymentBUS
    {
        private static PaymentBUS instance;
        public static PaymentBUS Instance => instance ?? (instance = new PaymentBUS());
        private PaymentBUS() { }

        public PaymentDTO GetPaymentInfo(string orderId)
        {
            return PaymentDAO.Instance.GetPaymentByOrderId(orderId);
        }

        public bool ProcessPayment(PaymentDTO pay)
        {
            if (string.IsNullOrEmpty(pay.OrderId)) return false;
            if (pay.AmountPaid < 0) return false;
            if (string.IsNullOrEmpty(pay.PaymentMethod)) pay.PaymentMethod = "Tiền mặt";

            PaymentDTO exist = PaymentDAO.Instance.GetPaymentByOrderId(pay.OrderId);
            if (exist != null)
            {
                return false;
            }

            return PaymentDAO.Instance.InsertPayment(pay);
        }
    }
}
