using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreWebApp.Core.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
