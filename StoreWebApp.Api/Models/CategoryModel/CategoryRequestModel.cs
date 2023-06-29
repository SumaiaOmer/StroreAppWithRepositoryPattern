using StoreWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Models.CategoryModel
{
    public class CategoryRequestModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
     
    }
}
