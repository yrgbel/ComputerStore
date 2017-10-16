using System;
using System.Web;

namespace Store.Web.Mvc.Client.Infrastructure
{
    // Stateful cart count is maintained by cookies
    public static class CurrentCart
    {
        public static int ItemCount
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies[".cartcount"];
                if (cookie == null) return 0;

                return int.Parse(cookie.Value);
            }
            set
            {
                var cookie = HttpContext.Current.Request.Cookies[".cartcount"];

                if (cookie == null)
                {
                    cookie = new HttpCookie(".cartcount", value.ToString());
                    cookie.Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    cookie.Value = value.ToString();
                }

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static string ItemCountForDisplay => ItemCount > 0 ? ItemCount.ToString() : "";
    }
}