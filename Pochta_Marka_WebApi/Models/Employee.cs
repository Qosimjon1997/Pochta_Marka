using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pochta_Marka_WebApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Passw { get; set; }

        [Required]
        public int Dostup { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
