using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pochta_Marka_Desktop.Services.Branch
{
    public class BranchService : IBranchService
    {
        public async Task<bool> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_BRANCH);

            var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";

        }

        public async Task<BranchModel> Get(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_BRANCH);
            var res = await client.GetAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            BranchModel model = JsonConvert.DeserializeObject<BranchModel>(response);
            return model;
        }

        public async Task<IEnumerable<BranchModel>> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_BRANCH);
            var res = await client.GetAsync(client.BaseAddress);
            string response = await res.Content.ReadAsStringAsync();
            IEnumerable<BranchModel> model = JsonConvert.DeserializeObject<IEnumerable<BranchModel>>(response);
            return model;
        }

        public async Task<bool> Post(BranchModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_BRANCH);

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }

        public async Task<bool> Update(int id, BranchModel model)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(API.ALL_BRANCH + $"/{id}");

            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(client.BaseAddress, content);
            string response = await res.Content.ReadAsStringAsync();
            return response == "true";
        }
    }
}
