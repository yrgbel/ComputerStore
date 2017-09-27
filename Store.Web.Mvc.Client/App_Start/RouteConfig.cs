using System.Web.Mvc;
using System.Web.Routing;

namespace Store.Web.Mvc.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Home",
                    action = "Index"
                }
            );
        }
    }
}
