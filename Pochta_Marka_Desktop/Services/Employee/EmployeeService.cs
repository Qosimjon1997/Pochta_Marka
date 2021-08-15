using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<bool> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE);

            var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<EmployeeModel> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE);
            var res = await client.GetAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            EmployeeModel model = JsonConvert.DeserializeObject<EmployeeModel>(response);
            return model;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE);
            var res = await client.GetAsync(client.BaseAddress);
            string response = await res.Content.ReadAsStringAsync();
            IEnumerable<EmployeeModel> model = JsonConvert.DeserializeObject<IEnumerable<EmployeeModel>>(response);
            return model;
        }

        public async Task<EmployeeModel> GetByLoginPass(string login, string passw)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE);
            var res = await client.GetAsync(client.BaseAddress + $"/{login}/{passw}");
            string response = await res.Content.ReadAsStringAsync();
            EmployeeModel model = JsonConvert.DeserializeObject<EmployeeModel>(response);
            return model;
        }

        public async Task<EmployeeModel> GetByPass(string passw)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE);
            var res = await client.GetAsync(client.BaseAddress + $"/{passw}");
            string response = await res.Content.ReadAsStringAsync();
            EmployeeModel model = JsonConvert.DeserializeObject<EmployeeModel>(response);
            return model;
        }

        public async Task<bool> Post(EmployeeModel employee)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE);

            string json = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<bool> Update(int id, EmployeeModel employee)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_EMPLOYEE + $"/{id}");

            string json = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }
    }
}
