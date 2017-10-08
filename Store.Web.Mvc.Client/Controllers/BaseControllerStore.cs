using System;
using System.Configuration;
using System.Web.Mvc;

namespace Store.Web.Mvc.Client.Controllers
{
    public class BaseControllerStore : Controller
    {
        protected string CurrentDomainPath =>
            Request.Url.Scheme +
            Uri.SchemeDelimiter +
            Request.Url.Host +
            (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

        protected Uri CurrentODateUri => new Uri(CurrentDomainPath + "/" + ConfigurationManager.AppSettings["routePrefix"]);
    }
}