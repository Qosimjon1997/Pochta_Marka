using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Product
{
    public class ProductService : IProductService
    {
        public async Task<bool> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCT);

            var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";

        }

        public async Task<ProductModel> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCT);
            var res = await client.GetAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            ProductModel model = JsonConvert.DeserializeObject<ProductModel>(response);
            return model;
        }

        public async Task<IEnumerable<ProductModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCT);
            var res = await client.GetAsync(client.BaseAddress);
            string response = await res.Content.ReadAsStringAsync();
            IEnumerable<ProductModel> model = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(response);
            return model;
        }

        public async Task<bool> Post(ProductModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCT);

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<bool> Update(int id, ProductModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_PRODUCT + $"/{id}");

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }
    }
}
