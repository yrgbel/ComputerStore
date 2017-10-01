using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Store.Data.MappingProfiles;
using Store.Web.Mvc.Client.App_Start;
using Store.Web.Mvc.Client.Infrastructure.MappingProfiles;

namespace Store.Web.Mvc.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingModelViewProfile>();
                c.AddProfile<MappingDtoProfile>();
            });
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
