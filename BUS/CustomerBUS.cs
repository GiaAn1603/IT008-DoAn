using System.Collections.Generic;
using OHIOCF.DAO;
using OHIOCF.DTO;

namespace OHIOCF.BUS
{
    public class CustomerBUS
    {
        private static CustomerBUS instance;
        public static CustomerBUS Instance => instance ?? (instance = new CustomerBUS());
        private CustomerBUS() { }

        public List<CustomerDTO> GetAllCustomers()
        {
            return CustomerDAO.Instance.GetListCustomer();
        }

        public CustomerDTO FindCustomerByPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return null;
            return CustomerDAO.Instance.GetCustomerByPhone(phone);
        }
        public CustomerDTO GetCustomerById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            return CustomerDAO.Instance.GetCustomerById(id);
        }

        public bool AddCustomer(CustomerDTO c)
        {
            if (string.IsNullOrEmpty(c.FullName) || string.IsNullOrEmpty(c.Phone)) return false;

            CustomerDTO exist = CustomerDAO.Instance.GetCustomerByPhone(c.Phone);
            if (exist != null) return false;

            return CustomerDAO.Instance.InsertCustomer(c);
        }

        public bool EditCustomer(CustomerDTO c)
        {
            if (string.IsNullOrEmpty(c.FullName)) return false;
            return CustomerDAO.Instance.UpdateCustomer(c);
        }

        public bool RemoveCustomer(string id)
        {
            return CustomerDAO.Instance.DeleteCustomer(id);
        }

        public void AddPointsAndUpdateRank(string customerId, decimal totalMoney)
        {
            var customer = CustomerDAO.Instance.GetCustomerById(customerId);
            if (customer == null) return;

            int earnedPoints = (int)(totalMoney / 10000) * 10;
            if (earnedPoints <= 0) return;

            int newTotalPoints = customer.Points + earnedPoints;

            string newRank;
            if (newTotalPoints >= 3000)
                newRank = "Kim cương";
            else if (newTotalPoints >= 1500)
                newRank = "Vàng";
            else if (newTotalPoints >= 500)
                newRank = "Bạc";
            else
                newRank = "Đồng";

            customer.Points = newTotalPoints;
            customer.Rank = newRank;

            CustomerDAO.Instance.UpdateCustomer(customer);
        }


    }
}
