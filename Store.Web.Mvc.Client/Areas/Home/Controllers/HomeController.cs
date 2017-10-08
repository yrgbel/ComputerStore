using System.Web.Mvc;
using Store.Web.Mvc.Client.Controllers;
using Store.Web.Mvc.Client.Infrastructure;

namespace Store.Web.Mvc.Client.Areas.Home.Controllers
{
    public class HomeController : BaseControllerStore
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}