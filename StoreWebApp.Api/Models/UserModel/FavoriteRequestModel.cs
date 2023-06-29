using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Models.UserModel
{
    public class FavoriteRequestModel
    {
        public int FavoriteId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

       

    }
}
