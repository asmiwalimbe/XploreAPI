using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XplorApplication.Models;

namespace XplorApplication.Services
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetAllCustomers();
        public Task<Customer> GetCustomerDetails(string id);
        public Task AddCustomer(Customer customer);
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomer(string id);
    }
}
