﻿using System.Configuration;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Store.DomainModel.DTOs;
using Store.Model.POCO_Entities;

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

            //config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: ConfigurationManager.AppSettings["routePrefix"],
                model: builder.GetEdmModel());
        }
    }
}