using StoreWebApp.Api.Models.CommonModel;
using StoreWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Models.CategoryModel
{
    public class CatogeryResponseModelcs
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public  Product Products { get; set; }
        public MessageResponseModel Message { get; set; }

    }
}
