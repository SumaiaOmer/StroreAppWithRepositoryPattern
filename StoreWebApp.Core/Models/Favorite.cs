using System;
using System.Collections.Generic;
using System.Text;

namespace StoreWebApp.Core.Models
{
  public  class Favorite
    {
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public Product product { get; set; }
        public User user { get; set; }
        

    }
}
