using Newtonsoft.Json;
using Pochta_Marka_Desktop.Services.Branch;
using Pochta_Marka_Desktop.Services.Sale;

namespace Pochta_Marka_Desktop.Services.Employee
{
    public class EmployeeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("passw")]
        public string Passw { get; set; }

        [JsonProperty("dostup")]
        public int Dostup { get; set; }

        [JsonProperty("branchId")]
        public int BranchId { get; set; }

        [JsonProperty("branch")]
        public BranchModel BranchModel { get; set; }

        [JsonProperty("sales")]
        public SaleModel SaleModel { get; set; }
    }
}
