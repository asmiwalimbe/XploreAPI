using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XplorApplication.Models;

namespace XplorApplication.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService()
        {

        }

        public async Task AddCustomer(Customer customer)
        {
            try
            {

                string apiUrl = "https://getinvoices.azurewebsites.net/api/Customer";

                // Serialize the newCustomer object to JSON
                string jsonPayload = JsonSerializer.Serialize(customer);
                // Create an instance of HttpClient
                using (var httpClient = new HttpClient())
                {
                    // Set the content type to JSON
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a new HTTP POST request with the JSON payload in the request body
                    var response = await httpClient.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Customer inserted successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception e)
            {
               throw new Exception("Failed to Add employee");
            }
        }

        public async Task DeleteCustomer(string id)
        {
            try
            {
                string apiUrl = $"https://getinvoices.azurewebsites.net/api/Customer/{id}";

                // Create an instance of HttpClient
                using (var httpClient = new HttpClient())
                {
                    // Send a DELETE request to the API
                    var response = await httpClient.DeleteAsync(apiUrl);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Customer deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                string apiUrl = "https://getinvoices.azurewebsites.net/api/Customers";

                // Create an instance of HttpClient
                using (var httpClient = new HttpClient())
                {
                    // Send the GET request to the API
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        customers = JsonSerializer.Deserialize<List<Customer>>(jsonResponse);
                    }
                }

            }
            catch(Exception ex)
            {
                
            }

            return customers;
        }

        public async Task<Customer> GetCustomerDetails(string id)
        {
            Customer customer = new Customer();
            try
            {
                string apiUrl = $"https://getinvoices.azurewebsites.net/api/Customer/{id}";

                // Create an instance of HttpClient
                using (var httpClient = new HttpClient())
                {
                    // Send a GET request to the API
                    var response = await httpClient.GetAsync(apiUrl);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a Customer object
                        customer = System.Text.Json.JsonSerializer.Deserialize<Customer>(jsonResponse);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("Customer not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {

                string apiUrl = $"https://getinvoices.azurewebsites.net/api/Customer/{customer.id}";

                // Serialize the newCustomer object to JSON
                string jsonPayload = JsonSerializer.Serialize(customer);
                // Create an instance of HttpClient
                using (var httpClient = new HttpClient())
                {
                    // Set the content type to JSON
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Create a new HTTP POST request with the JSON payload in the request body
                    var response = await httpClient.PostAsync(apiUrl, new StringContent(jsonPayload, Encoding.UTF8, "application/json"));

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Customer Updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Failed to Update employee");
            }
        }
    }
}
