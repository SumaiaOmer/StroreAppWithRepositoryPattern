using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Models.UserModel
{
    public class RegisterRequestModel
    {
      
        public string UserName { get; set; }
        
        public string UserPassword { get; set; }
       
        public string Email { get; set; }
     
        public string PhoneNumber { get; set; }
     
        public int RoleId { get; set; }
     
    }
}
