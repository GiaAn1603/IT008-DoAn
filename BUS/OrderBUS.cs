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

        public bool UpdateOrderInfo(string orderId, decimal totalAmount, string promotionId)
        {
            return OrderDAO.Instance.UpdateOrderInfo(orderId, totalAmount, promotionId);
        }

        public bool PayOrder(string orderId, decimal finalAmount, string customerId, string promotionId)
        {
            return OrderDAO.Instance.CheckoutOrder(orderId, finalAmount, customerId, promotionId);
        }

        public bool UpdatePromotion(string orderId, string promotionId)
        {
            return OrderDAO.Instance.UpdateOrderPromotion(orderId, promotionId);
        }
    }
}
