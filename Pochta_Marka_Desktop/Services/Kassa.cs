using System.ComponentModel.DataAnnotations;

namespace Pochta_Marka_Desktop.Services
{
    public class Kassa
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string myProduct { get; set; }
        public string myProductType { get; set; }

        public int mySoni { get; set; }
        public int mySumma { get; set; }


    }
}
