using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductWeb.Data
{
    public class CustomerRepository : IRepository<CustomerDto>
    {
        readonly IConfiguration configuration;
        public CustomerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<CustomerDto> CreateAsync(CustomerDto entity)
        {
            CustomerDto customer = null;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://ermx-customers-api.azurewebsites.net/api/Customers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerDto>(apiResponse);
                }
            }
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = false;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://ermx-customers-api.azurewebsites.net/api/Customers?id=" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<bool>(apiResponse);
                }
            }
            return result;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = new List<CustomerDto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://ermx-customers-api.azurewebsites.net/api/Customers/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customers = JsonConvert.DeserializeObject<List<CustomerDto>>(apiResponse);
                }
            }
            return customers;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            CustomerDto customer = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://ermx-customers-api.azurewebsites.net/api/Customers/id?id=" + id.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerDto>(apiResponse);
                }
            }
            return customer;
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto entity)
        {
            CustomerDto customer = null;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("http://ermx-customers-api.azurewebsites.net/api/Customers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerDto>(apiResponse);
                }
            }
            return customer;
        }


    }
}
