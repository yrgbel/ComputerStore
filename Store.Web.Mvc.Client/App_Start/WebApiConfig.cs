using System.Configuration;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Store.DomainModel.DTOs;

namespace Store.Web.Mvc.Client
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            ////// OData configuration
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EnableLowerCamelCase();

            builder.EntitySet<ProductDetailsDto>("Products").EntityType.Name = "Product";
            builder.EntitySet<ProductBrandDto>("ProductBrands").EntityType.Name = "ProductBrand";
            builder.EntitySet<CartDto>("Carts").EntityType.Name = "Cart";
            builder.EntitySet<CartItemDto>("CartItems").EntityType.Name = "CartItem";

            //config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: ConfigurationManager.AppSettings["routePrefix"],
                model: builder.GetEdmModel());
        }
    }
}