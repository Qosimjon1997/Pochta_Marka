using Newtonsoft.Json;
using Pochta_Marka_Desktop.Services.Product;
using Pochta_Marka_Desktop.Services.Sale;
using System.Collections.Generic;

namespace Pochta_Marka_Desktop.Services.ProductType
{
    public class ProductTypeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("product")]
        public ProductModel Product { get; set; }

        [JsonProperty("sales")]
        public List<SaleModel> Sales { get; set; }
    }
}
