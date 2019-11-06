using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Model;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IProductRepository _productrepository;
        private IPurchaseRepository _purchaserepository;

        public HomeController(IProductRepository productRepository, IPurchaseRepository purchaserepository)
        {
            _productrepository = productRepository;
            _purchaserepository = purchaserepository;
        }

        [HttpGet]
        public List<ProductDetail> Get()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var model =  _productrepository.GetAllProducts();
            
            List<ProductDetail> lstProduct = new List<ProductDetail>();
            foreach (var p in model)
            {
                ProductDetail obj = new ProductDetail();
                obj.Id = p.Id;
                obj.Name = p.Name;
                obj.Path = p.Path;
                obj.Price = p.Price;
                obj.Description = p.Description;

                lstProduct.Add(obj);
            }
            return lstProduct;
        }

        [HttpPost]
        [Route("SelectedProducts")]
        public  ActionResult PostSelectedProducts(List<ProductDetail> model)
        {
            Purchase p = new Purchase();
            foreach (var m in model)
            {
                if (m.Checked)
                {
                    Guid obj = Guid.NewGuid();
                    p.Id = obj.ToString();
                    p.ProductId = m.Id;
                    p.UserId = User.Claims.First(c => c.Type == "UserID").Value;
                     _purchaserepository.Add(p);
                }
            }
            return Ok();
        }
    }
}