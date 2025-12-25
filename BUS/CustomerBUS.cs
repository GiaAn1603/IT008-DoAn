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
    }
}
