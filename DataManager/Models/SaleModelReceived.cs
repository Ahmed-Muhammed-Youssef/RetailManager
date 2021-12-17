using System.ComponentModel.DataAnnotations;

namespace DataManager.Models
{
    public class SaleModelReceived
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
