using Newtonsoft.Json;

namespace Pochta_Marka_Desktop.Services.Product
{
    public class ProductModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        
    }
}
