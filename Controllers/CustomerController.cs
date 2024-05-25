using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class CustomerController
    {
        private List<Customer> customers = new List<Customer>();

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer? GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = GetCustomerById(customer.CustomerID);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }
    }
}
