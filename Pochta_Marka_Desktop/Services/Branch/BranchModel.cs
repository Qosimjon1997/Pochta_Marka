using Newtonsoft.Json;

namespace Pochta_Marka_Desktop.Services.Branch
{
    public class BranchModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("branchNumber")]
        public string BranchNumber { get; set; }

        [JsonProperty("branchAddress")]
        public string BranchAddress { get; set; }

    }
}
