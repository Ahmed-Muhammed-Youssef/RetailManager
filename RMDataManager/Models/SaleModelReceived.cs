﻿using System.ComponentModel.DataAnnotations;

namespace RMDataManager.Models
{
    public class SaleModelReceived
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
