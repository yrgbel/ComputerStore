using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Store.DomainModel.DTOs;
using Store.Web.Mvc.Client.Controllers;

namespace Store.Web.Mvc.Client.Areas.Store.Controllers
{
    public class ProductController : BaseControllerStore
    {
        [ChildActionOnly]
        public ActionResult TopDiscountProducts(int count = 15)
        {
            var products = Context.Products
                .Where(p => p.productDiscount > 0)
                .OrderByDescending(p => p.productDiscount)
                .Take(count)
                .ToList();

            var productDtos = Mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return PartialView("_Products", productDtos);
        }

        [ChildActionOnly]
        public ActionResult MostPopularProducts(int count = 20)
        {
            var products = Context.Products
                .OrderByDescending(p => p.productOrderCount)
                .Take(count)
                .ToList();

            var productDtos = Mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return PartialView("_Products", productDtos);
        }

        #region NavBrands (commented)

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

        #endregion

        public ActionResult Product(int id)
        {
            Product product = Context.Products
                .Where(p => p.productId == id)
                .ToList()
                .FirstOrDefault();

            if (product == null)
            {
                return View("Error");
            }

            var productDto = Mapper.Map<ProductDetailsDto>(product);

            return View("Product", productDto);
        }
    }
}