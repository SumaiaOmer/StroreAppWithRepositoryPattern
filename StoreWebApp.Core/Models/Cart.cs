using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreWebApp.Core.Models
{
   public  class Cart
    {
        [Key]
        public int CartId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int quantity { get; set; }
        public Product product { get; set; }
        public User user { get; set; }

    }
}
