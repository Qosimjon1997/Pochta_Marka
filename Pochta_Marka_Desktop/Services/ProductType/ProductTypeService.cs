using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.ProductType
{
    public class ProductTypeService : IProductTypeService
    {
        public async Task<bool> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCTTYPE);

            var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";

        }

        public async Task<ProductTypeModel> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCTTYPE);
            var res = await client.GetAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            ProductTypeModel model = JsonConvert.DeserializeObject<ProductTypeModel>(response);
            return model;
        }

        public async Task<IEnumerable<ProductTypeModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCTTYPE);
            var res = await client.GetAsync(client.BaseAddress);
            string response = await res.Content.ReadAsStringAsync();
            IEnumerable<ProductTypeModel> model = JsonConvert.DeserializeObject<IEnumerable<ProductTypeModel>>(response);
            return model;
        }

        public async Task<bool> Post(ProductTypeModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCTTYPE);

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<bool> Update(int id, ProductTypeModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCTTYPE + $"/{id}");

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }
    }
}
