using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using StoreWebApp.Core.Interface;
using StoreWebApp.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;

namespace StoreWebApp.Api.Helpers
{
    public class Helper
    {
        private readonly IBaseRepository<Cart> _cart;
        private readonly IBaseRepository<Product> _product;
        private readonly IBaseRepository<User> _user;

        public Helper(IBaseRepository<Cart> cart, IBaseRepository<Product> product , IBaseRepository<User> _user)
        {

            _cart = cart;
            _product = product;
        }

        public Helper()
        {
        }

        public Product GetProductObj(int productId)
        {
            var Getquantity = _product.GetById(productId);
            return Getquantity;

        }
        public string GetPW(int UserId)
        {
            var Getpw = _user.GetById(UserId).UserPassword;
            return Getpw;

        }
        public int UpdateQuantity(int productId, int quantity)
        {
            var obj = GetProductObj(productId);
            var data = _product.ModifyData(new Product
            {

                ProductId = productId,
                quantity = obj.quantity - quantity,
                ProductName = obj.ProductName,
                ProductImage = obj.ProductImage,
                CategoryId = obj.CategoryId,
                price = obj.price
            });
            return _product.complate();
        }
        public int Log(int productId, int quantity, int UserId)
        {
            var log = _cart.AddData(new Cart
            {

                ProductId = productId,
                quantity = quantity,
                UserId = UserId,



            });
            return _cart.complate();
        }

        public string EncryptData(string UserPassword)
        {
           
            StreamReader s = new StreamReader(@"KeyFolder\PublicKey.pem");
            //Read the first line of text

            string PublicKey = s.ReadToEnd(); //System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/PublicKey.pem");
            
          
            string ecryptdPassword = RsaEncryptWithPublic(UserPassword, PublicKey);

            return ecryptdPassword;


        }

        public string DecryptData(string UserPassword)
        {
            try
            {
              
                string decryptedPassword = "";

                StreamReader s = new StreamReader(@"KeyFolder\PrivateKey.pem");
                //Read the first line of text
                string PrivateKey = s.ReadToEnd(); //System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/PrivateKey.pem");

                if (UserPassword != null)
                            decryptedPassword = RsaDecryptWithPrivate(UserPassword, PrivateKey);
                        else
                            decryptedPassword = "";
                    
               
                return decryptedPassword;

            }
            catch (Exception ex)
            {
                return "";
            }
        }



        public string RsaDecryptWithPrivate(string base64Input, string privateKey)
        {
            var bytesToDecrypt = Convert.FromBase64String(base64Input);

            AsymmetricCipherKeyPair keyPair;
            var decryptEngine = new Pkcs1Encoding(new RsaEngine());

            using (var txtreader = new StringReader(privateKey))
            {
                keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();

                decryptEngine.Init(false, keyPair.Private);
            }

            var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
            return decrypted;
        }

        public string RsaEncryptWithPublic(string clearText, string publicKey)
        {
            try
            {
                var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);

                var encryptEngine = new Pkcs1Encoding(new RsaEngine());

                using (var txtreader = new StringReader(publicKey))
                {
                    var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();

                    encryptEngine.Init(true, keyParameter);
                }

                var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
                return encrypted;
            }
            catch (Exception ex)
            {

                return "";
            }
        

        }

              public bool compareVal(string val1 , string val2)
        {
            if (val1.Equals(val2))
                return true;
            else
                return false;

        }

    }
  
}
