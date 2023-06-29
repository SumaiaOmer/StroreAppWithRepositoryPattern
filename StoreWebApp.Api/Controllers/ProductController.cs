using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebApp.Api.Models.ProductModel;
using StoreWebApp.Core.Interface;
using StoreWebApp.Core.Models;

namespace StoreWebApp.Api.Controllers
{
     
    public class ProductController : ControllerBase
    {
        private readonly IBaseRepository<Product> _product;

        public ProductController(IBaseRepository<Product> product)
        {
            _product = product;

        }

        [HttpPost]
        [Route("api/product/addproduct")]

        public async Task<IActionResult> Add([FromBody]ProductRequestModel model)
        {


            var data = _product.AddData(new Product
            {
                CategoryId = model.CategoryId,
                price = model.price,
                ProductImage = model.ProductImage,
                ProductName = model.ProductName,
                quantity = model.quantity


            });
            var IsComplate = _product.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }


        [HttpGet]
        [Route("api/product/getproduct")]

        public async Task<IActionResult> GetAll()
        {
             return Ok(_product.GetAllAsync());
        }

        [HttpGet]
        [Route("api/product/getproductbyid")]

        public async Task<IActionResult> GetById([FromBody]ProductRequestModel model)
        {

            return Ok(await _product.GetByIdAsync(model.ProductId));

        }


        [HttpPost]
        [Route("api/product/modifyproduct")]

        public async Task<IActionResult> Modify([FromBody]ProductRequestModel model)
        {


            var data = _product.AddData(new Product
            {
                ProductId = model.ProductId,
                CategoryId = model.CategoryId,
                price = model.price,
                ProductImage = model.ProductImage,
                ProductName = model.ProductName,
                quantity = model.quantity



            });
            var IsComplate = _product.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }

        [HttpPost]
        [Route("api/product/removeproduct")]

        public async Task<IActionResult> Remove([FromBody]ProductRequestModel model)
        {


            var data = _product.RemoveData(new Product
            {
                CategoryId = model.ProductId,


            });
            var IsComplate = _product.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }
    }
}