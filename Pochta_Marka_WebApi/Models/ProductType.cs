using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pochta_Marka_WebApi.Models
{
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public List<Sale> Sales { get; set; }

    }
}
