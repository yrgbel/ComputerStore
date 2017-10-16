﻿using System.Web.Mvc;

namespace Store.Web.Mvc.Client.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Store";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // Default route for child actions.
            context.MapRoute(
                "StoreDefault",
                "Store/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );

            context.MapRoute("", "products/{id}", defaults: new { controller = "Product", action = "Product", area = "Store" });
            context.MapRoute("", "cart", defaults: new { controller = "Cart", action = "Cart", area = "Store" });

        }
    }
}