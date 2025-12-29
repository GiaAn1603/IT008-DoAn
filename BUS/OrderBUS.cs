using System;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class OrderBUS
    {
        private static OrderBUS instance;
        public static OrderBUS Instance => instance ?? (instance = new OrderBUS());
        private OrderBUS() { }

        public OrderDTO GetUncheckOrderByTable(string tableId)
        {
            return OrderDAO.Instance.GetUnpaidOrderByTable(tableId);
        }

        public string CreateOrder(string tableId, string userId)
        {
            OrderDTO existingOrder = OrderDAO.Instance.GetUnpaidOrderByTable(tableId);
            if (existingOrder != null)
            {
                return existingOrder.Id;
            }

            string newId = Guid.NewGuid().ToString();
            OrderDTO order = new OrderDTO
            {
                Id = newId,
                TableId = tableId,
                UserId = userId,
                TotalAmount = 0,
                Status = 0
            };

            if (OrderDAO.Instance.InsertOrder(order))
                return newId;

            return null;
        }

        public void UpdateOrderInfo(string orderId,decimal total,string promoId,string customerId)
             {
               OrderDAO.Instance.UpdateOrderInfo(
                orderId,
                total,
                promoId,
                customerId
              );
              }


        public bool PayOrder(string orderId, decimal finalAmount, string customerId, string promotionId)
        {
            bool result = OrderDAO.Instance.CheckoutOrder(
                orderId,
                finalAmount,
                customerId,
                promotionId
            );

            if (result && !string.IsNullOrEmpty(customerId))
            {
                CustomerBUS.Instance.AddPointsAndUpdateRank(customerId, finalAmount);
            }

            return result;
        }



        public bool UpdatePromotion(string orderId, string promotionId)
        {
            return OrderDAO.Instance.UpdateOrderPromotion(orderId, promotionId);
        }
        public int GetInvoiceCount()
        {
            return OrderDAO.Instance.GetInvoiceCount();
        }

        public decimal GetTotalRevenue()
        {
            return OrderDAO.Instance.GetTotalRevenue();
        }
        public decimal GetTodayRevenue()
        {
            return OrderDAO.Instance.GetTodayRevenue();
        }


    }
}
