using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Default;
using Store.DomainModel.DTOs;
using Store.Web.Mvc.Client.Controllers;
using PocoEntities = Store.Model.POCO_Entities;

namespace Store.Web.Mvc.Client.Areas.Store.Controllers
{
    public class ProductController : BaseControllerStore
    {
        [ChildActionOnly]
        public ActionResult TopDiscountProducts(int count = 15)
        {
            Container context = new Container(CurrentODateUri);

            var products = context.Products
                .Where(p => p.productDiscount > 0)
                .OrderByDescending(p => p.productDiscount)
                .Take(count)
                .ToList();

            var productEntities = Mapper.Map<IEnumerable<PocoEntities.Product>>(products);
            var productDtos = Mapper.Map<IEnumerable<ProductDetailsDto>>(productEntities);

            return PartialView("_Products", productDtos);
        }

        [ChildActionOnly]
        public ActionResult MostPopularProducts(int count = 20)
        {
            Container context = new Container(CurrentODateUri);

            var products = context.Products
                .OrderByDescending(p => p.productOrderCount)
                .Take(count)
                .ToList();

            var productEntities = Mapper.Map<IEnumerable<PocoEntities.Product>>(products);
            var productDtos = Mapper.Map<IEnumerable<ProductDetailsDto>>(productEntities);

            return PartialView("_Products", productDtos);
        }

        //public ActionResult NavBrands(int count = 4)
        //{
        //    Container context = new Container(CurrentODateUri);

        //    IEnumerable<string> brands = context.ProductBrands
        //        .ToList()
        //        .OrderBy(b => b.productBrandName)
        //        .Take(count)
        //        .Select(b => b.productBrandName.ToUpper())
        //        .Concat(new string[] {"ASUS", "LENOVO", "DELL", "ACER", "MSI" }) //for testing
        //        .Distinct();

        //    return PartialView("_NavBrands", brands);
        //}
    }
}