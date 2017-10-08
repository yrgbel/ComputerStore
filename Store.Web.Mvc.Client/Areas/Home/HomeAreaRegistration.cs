using System.Web.Mvc;

namespace Store.Web.Mvc.Client.Areas.Home
{
    public class HomeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Home";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("", "", defaults: new { controller = "Home", action = "Index", area = "Home" });
        }
    }
}