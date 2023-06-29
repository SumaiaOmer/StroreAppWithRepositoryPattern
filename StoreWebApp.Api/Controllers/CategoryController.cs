using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebApp.Api.Models.CategoryModel;
using StoreWebApp.Core.Interface;
using StoreWebApp.Core.Models;

namespace StoreWebApp.Api.Controllers
{
   
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Category> _category;
   
        public CategoryController(IBaseRepository<Category> category  )
        {
            _category = category;
          
        }

        [HttpPost]
        [Route("api/category/addcategory")]

        public async Task<IActionResult> Add([FromBody]CategoryRequestModel model)
        {
           

            var data = _category.AddData(new Category
            {
              CategoryName = model.CategoryName


            });
            var IsComplate = _category.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }


        [HttpGet]
        [Route("api/category/getcategories")]

        public async Task<List<CatogeryResponseModelcs>> GetAll()
        {
           
            var resplist = new List<CatogeryResponseModelcs>();

            var data = _category.GetAllAsyncWithJoin("Products");
            foreach (var item in data)
            {
                var resp = new CatogeryResponseModelcs();
          
                resp.CategoryId = item.CategoryId;
                resp.CategoryName = item.CategoryName;
                foreach (var prodItem in item.Products)
                {


                    resp.Products = new Product();
                    resp.Products.ProductId = prodItem.ProductId;
                    resp.Products.ProductImage = prodItem.ProductImage;
                    resp.Products.price = prodItem.price;
                    resp.Products.quantity = prodItem.quantity;
                    resp.Products.ProductName = prodItem.ProductName;
                  
                }
                resplist.Add(resp);
            }
            return resplist;
        }

        [HttpGet]
        [Route("api/category/getcategorybyid")]

        public async Task<IActionResult> GetById([FromBody]CategoryRequestModel model)
        {
            var data = _category.GetByIdAsync(model.CategoryId);
            return Ok( data);

        }


        [HttpPost]
        [Route("api/category/modifycategory")]

        public async Task<IActionResult> Modify([FromBody]CategoryRequestModel model)
        {


            var data = _category.ModifyData(new Category
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName


            });
            var IsComplate = _category.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }

        [HttpPost]
        [Route("api/category/removecategory")]

        public async Task<IActionResult> Remove([FromBody]CategoryRequestModel model)
        {


            var data = _category.RemoveData(new Category
            {
                CategoryId = model.CategoryId,
             

            });
            var IsComplate = _category.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }
    }
}