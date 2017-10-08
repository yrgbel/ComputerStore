using System.Web.Mvc;

namespace Store.Web.Mvc.Client.Areas.Store
{
    public class StoreAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Store";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            // Default route for child actions.
            context.MapRoute(
                "StoreDefault",
                "Store/{controller}/{action}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}