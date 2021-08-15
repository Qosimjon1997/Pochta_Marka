using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pochta_Marka_WebApi.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BranchNumber { get; set; }
        public string BranchAddress { get; set; }

        public List<Employee> Employees { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
