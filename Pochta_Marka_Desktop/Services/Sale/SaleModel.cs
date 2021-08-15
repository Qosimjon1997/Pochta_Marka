using Newtonsoft.Json;
using Pochta_Marka_Desktop.Services.Branch;
using Pochta_Marka_Desktop.Services.Employee;
using Pochta_Marka_Desktop.Services.Product;
using Pochta_Marka_Desktop.Services.ProductType;
using System;

namespace Pochta_Marka_Desktop.Services.Sale
{
    public class SaleModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("branchId")]
        public int BranchId { get; set; }


        [JsonProperty("employeeId")]
        public int EmployeeId { get; set; }


        [JsonProperty("productId")]
        public int ProductId { get; set; }


        [JsonProperty("productTypeId")]
        public int ProductTypeId { get; set; }


        [JsonProperty("soni")]
        public int Soni { get; set; }

        [JsonProperty("summasi")]
        public decimal Summasi { get; set; }

        [JsonProperty("saleTime")]
        public DateTime SaleTime { get; set; }

    }
}
