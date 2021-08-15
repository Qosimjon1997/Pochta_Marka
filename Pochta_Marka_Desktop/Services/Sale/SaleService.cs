using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Sale
{
    public class SaleService : ISaleService
    {
        public async Task<bool> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_SALE);

            var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";

        }

        public async Task<SaleModel> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_SALE);
            var res = await client.GetAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            SaleModel model = JsonConvert.DeserializeObject<SaleModel>(response);
            return model;
        }

        public async Task<IEnumerable<SaleModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_SALE);
            var res = await client.GetAsync(client.BaseAddress);
            string response = await res.Content.ReadAsStringAsync();
            IEnumerable<SaleModel> model = JsonConvert.DeserializeObject<IEnumerable<SaleModel>>(response);
            return model;
        }

        public async Task<bool> Post(IEnumerable<SaleModel> model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_SALE);

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<bool> Update(int id, SaleModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_SALE + $"/{id}");

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }
    }
}
