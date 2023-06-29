using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Models.UserModel
{
    public class CartRequestModel
    {
        
        public int CartId { get; set; }
        
        public int ProductId { get; set; }
      
        public int UserId { get; set; }
        
        public int quantity { get; set; }
        
    }
}
