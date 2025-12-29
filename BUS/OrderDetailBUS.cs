using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class OrderDetailBUS
    {
        private static OrderDetailBUS instance;
        public static OrderDetailBUS Instance => instance ?? (instance = new OrderDetailBUS());
        private OrderDetailBUS() { }

        public List<OrderDetailDTO> GetDetails(string orderId)
        {
            return OrderDetailDAO.Instance.GetListDetailByOrderId(orderId);
        }

        public bool AddDishToOrder(OrderDetailDTO detail)
        {
            OrderDetailDTO existItem = OrderDetailDAO.Instance.GetDetailByOrderProductSize(detail.OrderId, detail.ProductId, detail.ProductSizeId);

            bool result = false;
            if (existItem != null)
            {
                existItem.Quantity += detail.Quantity;
                result = OrderDetailDAO.Instance.UpdateOrderDetail(existItem);
            }
            else
            {
                result = OrderDetailDAO.Instance.InsertOrderDetail(detail);
            }

            if (result)
            {
                UpdateOrderTotal(detail.OrderId);
            }

            return result;
        }

        public bool UpdateDishQuantity(string detailId, int newQuantity, string orderId)
        {
            UpdateOrderTotal(orderId);
            return true;
        }

        public bool RemoveDish(string detailId, string orderId)
        {
            bool result = OrderDetailDAO.Instance.DeleteOrderDetail(detailId);
            if (result)
            {
                UpdateOrderTotal(orderId);
            }
            return result;
        }

        private void UpdateOrderTotal(string orderId)
        {
            decimal total = OrderDetailDAO.Instance.GetTotalAmountByOrderId(orderId);
            OrderDAO.Instance.UpdateOrderTotal(orderId, total);
        }
    }
}
