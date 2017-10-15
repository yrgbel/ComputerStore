using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Store.Data.Contracts;
using Store.DomainModel.DTOs;
using Store.Model.POCO_Entities;
using Store.Web.Mvc.Client.Controllers;

namespace Store.Web.Mvc.Client.Areas.Store.Controllers
{
    public class ProductController : BaseControllerStore
    {
        public ProductController(IStoreUow uow)
        {
            Uow = uow;
        }

        [ChildActionOnly]
        public ActionResult TopDiscountProducts(int count = 15)
        {
            var products = Uow.Products
                .GetAll()
                .Where(p => p.ProductDiscount > 0)
                .Take(count)
                .OrderByDescending(p => p.ProductDiscount)
                .ToList();

            var productDtos = Mapper.Map<IEnumerable<ProductDetailsDto>>(products);

            return PartialView("_Products", productDtos);
        }

        [ChildActionOnly]
        public ActionResult MostPopularProducts(int count = 20)
        {
            var products = Uow.Products
                .GetAll()
                .Take(count)
                .OrderByDescending(p => p.ProductOrderCount)
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
            Product product = Uow.Products.GetById(id);

            if (product == null)
            {
                return View("Error");
            }

            var productDto = Mapper.Map<ProductDetailsDto>(product);

            return View("Product", productDto);
        }
    }
}