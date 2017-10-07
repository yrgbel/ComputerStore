using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Default;
using Store.DomainModel.DTOs;

namespace Store.Web.Mvc.Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult TopDiscountProducts(int count = 15)
        {
            string domain = Request.Url.Scheme +
                            Uri.SchemeDelimiter +
                            Request.Url.Host +
                            (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

            Uri uri = new Uri(domain + "/odata");
            Container context = new Container(uri);

            var products = context.Products
                .Where(p => p.productDiscount > 0)
                .OrderByDescending(p => p.productDiscount)
                .Take(count)
                .ToList();


            var productEntities = Mapper.Map<IEnumerable<Model.POCO_Entities.Product>>(products);
            var productDtos = Mapper.Map<IEnumerable<ProductDetailsDto>>(productEntities);

            return PartialView("_Products", productDtos);
        }
    }
}