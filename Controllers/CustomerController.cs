using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XplorApplication.Models;
using XplorApplication.Services;

namespace XplorApplication.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/GetAllCustomer
        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return customers;
        }

        // GET: api/Customer
        [HttpGet]
        [Route("GetCustomer/{id}")]
        public async Task<Customer> GetCustomerDetails(string id)
        {
            return await _customerService.GetCustomerDetails(id);
        }

        // GET: api/Customer
        [HttpPost]
        [Route("Add")]
        public async Task AddCustomer([FromBody]Customer customer)
        {
            await  _customerService.AddCustomer(customer);
        }

        // GET: api/Customer
        [HttpPut]
        [Route("Update")]
        public async Task UpdateCustomer([FromBody]Customer customer)
        {
            await _customerService.UpdateCustomer(customer);
        }

        // GET: api/Customer
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task DeleteCustomer(string id)
        {
            await _customerService.DeleteCustomer(id);
        }
    }
}
