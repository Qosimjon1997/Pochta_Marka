using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pochta_Marka_WebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public List<ProductType> ProductTypes { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
