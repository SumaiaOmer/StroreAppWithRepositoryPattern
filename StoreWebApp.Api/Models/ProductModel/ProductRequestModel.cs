using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Models.ProductModel
{
    public class ProductRequestModel
    {
         
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public string ProductImage { get; set; }
        
        public double price { get; set; }
        
        public int quantity { get; set; }
   
        public int CategoryId { get; set; }
    }
}
