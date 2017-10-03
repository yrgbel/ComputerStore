using System.Web.Mvc;

namespace Store.Web.Mvc.Client.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Auth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("", "signup", defaults: new { controller = "Auth", action = "Signup", area = "Auth" });
            context.MapRoute("", "login", defaults: new { controller = "Auth", action = "Login", area = "Auth" });
            context.MapRoute("", "logout", defaults: new { controller = "Auth", action = "Logout", area = "Auth" });
            context.MapRoute("", "logout/confirm", defaults: new { controller = "Auth", action = "LogoutConfirm", area = "Auth" });
        }
    }
}