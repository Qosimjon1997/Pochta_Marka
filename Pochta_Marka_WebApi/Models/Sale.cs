using System;
using System.ComponentModel.DataAnnotations;

namespace Pochta_Marka_WebApi.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        
        public int BranchId { get; set; }

        
        public int EmployeeId { get; set; }

        
        public int ProductId { get; set; }

        
        public int ProductTypeId { get; set; }

        public int Soni { get; set; }

        public decimal Summasi { get; set; }

        public DateTime SaleTime { get; set; }


    }
}
