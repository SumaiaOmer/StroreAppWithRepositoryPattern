using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreWebApp.Api.Helpers;
using StoreWebApp.Api.Models.UserModel;
using StoreWebApp.Core.Interface;
using StoreWebApp.Core.Models;

namespace StoreWebApp.Api.Controllers
{
    
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<User> _user ;
        private readonly IBaseRepository<Cart> _cart;
        private readonly IBaseRepository<Favorite> _favorite;
        private readonly IBaseRepository<Product> _product;
        Helper helper = new Helper();

        public UserController(IBaseRepository<User> user, IBaseRepository<Cart> cart , IBaseRepository<Favorite> favorite , IBaseRepository<Product> product)
        {
            _user = user;
            _cart = cart;
            _favorite = favorite;
            _product = product;
           
        }
        [HttpPost]
        [Route("api/user/register")]

        public async Task<IActionResult>  Register([FromBody]RegisterRequestModel model)
        {
           
         
                var data = _user.AddData(new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    RoleId = model.RoleId,
                    PhoneNumber = model.PhoneNumber,
                    UserPassword = helper.EncryptData(model.UserPassword)



                });
                var IsComplate = _user.complate();
                if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();





        }

        [HttpPost]
        [Route("api/user/login")]

        public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        {
           

            var result = _user.GetEntities(x => x.Email.Equals(model.Email));
            if(result.Count()==0 )
                return NotFound();

            else
            {
                var decryptPw = helper.DecryptData(model.UserPassword);
                var userId = _user.GetEntitie(x => x.Email.Equals(model.Email)).UserId;
                var PwDb = _user.GetById(userId).UserPassword;


                if (helper.compareVal(helper.DecryptData(PwDb), decryptPw)) 

                   return Ok();
                else
                   return NotFound();

            }
 
        }


        [HttpPost]
        [Route("api/user/addcart")]

        public async Task<IActionResult> AddToCart([FromBody]CartRequestModel model)
        {
            var  _helper = new Helper(_cart, _product, _user);
          


            var IsComplate = _helper.UpdateQuantity(model.ProductId , model.quantity);
            if (IsComplate > 0)
            {

                _helper.Log(model.ProductId , model.quantity ,model.UserId);
                return Ok();
            }
              else
                return BadRequest();

        }


        [HttpPost]
        [Route("api/user/addtocart")]

        public async Task<IActionResult> AddToFavorite([FromBody]FavoriteRequestModel model)
        {


            var data = _favorite.AddData(new Favorite
            {

                ProductId = model.ProductId,
             
                UserId = model.UserId

            });
            var IsComplate = _favorite.complate();
            if (IsComplate > 0)
                return Ok();


            else
                return BadRequest();

        }

    }
}