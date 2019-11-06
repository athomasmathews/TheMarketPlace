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
    public class MyItemsController : ControllerBase
    {
        private IProductRepository _productrepository;
        private IPurchaseRepository _purchaserepository;

        public MyItemsController(IProductRepository productRepository, IPurchaseRepository purchaserepository)
        {
            _productrepository = productRepository;
            _purchaserepository = purchaserepository;
        }
        [HttpGet]
        public List<ProductDetail> Get()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var purchasedproducts = _purchaserepository.GetAllPurchases().Where(x => x.UserId == userId);


            var model = _productrepository.GetAllProducts();

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

            List<ProductDetail> myproducts = new List<ProductDetail>();


            foreach(var p in purchasedproducts)
            {
                ProductDetail obj = new ProductDetail();
                obj.Id = lstProduct.Where(x => x.Id == p.ProductId).FirstOrDefault().Id;
                obj.Name = lstProduct.Where(x => x.Id == p.ProductId).FirstOrDefault().Name;
                obj.Path = lstProduct.Where(x => x.Id == p.ProductId).FirstOrDefault().Path;
                obj.Price = lstProduct.Where(x => x.Id == p.ProductId).FirstOrDefault().Price;
                obj.Description = lstProduct.Where(x => x.Id == p.ProductId).FirstOrDefault().Description;
                myproducts.Add(obj);
            }
            return myproducts;
        }
        [HttpPost]
        [Route("CancelledProducts")]
        public ActionResult CancelledProducts(List<ProductDetail> model)
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var allpurchases = _purchaserepository.GetAllPurchases().Where(x => x.UserId == userId).ToList();

            foreach (var m in model)
            {
                if (m.Checked)
                {
                    foreach(var a in allpurchases)
                    {
                        if (a.ProductId == m.Id)
                        {
                            _purchaserepository.Delete(a);
                        }
                    }
                }
            }
            return Ok();
        }
    }
}