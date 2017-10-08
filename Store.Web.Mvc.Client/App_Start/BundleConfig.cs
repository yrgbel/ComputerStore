using System.Web.Optimization;

namespace Store.Web.Mvc.Client.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Force optimization to be on or off, regardless of web.config setting
            //BundleTable.EnableOptimizations = false;
            bundles.UseCdn = false;

            // .debug.js, -vsdoc.js and .intellisense.js files 
            // are in BundleTable.Bundles.IgnoreList by default.
            // Clear out the list and add back the ones we want to ignore.
            // Don't add back .debug.js.
            bundles.IgnoreList.Clear();
            bundles.IgnoreList.Ignore("*intellisense.js");

            // Modernizr goes separate since it loads first
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/lib/modernizr-{version}.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery",
                    "//ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js")
                .Include("~/Scripts/lib/jquery-{version}.js"));

            // 3rd Party JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/jsextlibs")
                //.IncludeDirectory("~/Scripts/lib", "*.js", searchSubdirectories: false));
                .Include(
                    "~/Scripts/lib/bootstrap.js",
                    "~/Scripts/lib/bootstrap-slider.js",
                    "~/Scripts/lib/json2.js", // IE7 needs this

                    // jQuery plugins
                    //"~/Scripts/lib/activity-indicator.js",
                    //"~/Scripts/lib/jquery.mockjson.js",
                    //"~/Scripts/lib/TrafficCop.js",
                    //"~/Scripts/lib/infuser.js", // depends on TrafficCop

                    // Other 3rd party libraries
                    "~/Scripts/lib/underscore.js", // functional framework
                    "~/Scripts/lib/moment.js",
                    //"~/Scripts/lib/amplify.*",
                    "~/Scripts/lib/toastr.js"// bublle notification
                ));
            //bundles.Add(new ScriptBundle("~/bundles/jsmocks")
            //    .IncludeDirectory("~/Scripts/app/mock", "*.js", searchSubdirectories: false));

            //// All application JS files
            //bundles.Add(new ScriptBundle("~/bundles/jsapplibs")
            //    .IncludeDirectory("~/Scripts/app/", "*.js", searchSubdirectories: false));

            // 3rd Party CSS files
            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-slider.css",
                    "~/Content/bootstrap-theme.css",
                    "~/Content/toastr.css",
                    "~/Content/toastr-responsive.css"));
               
            // Custom CSS files
            bundles.Add(new StyleBundle("~/Content/custom-css")
                .Include(
                    "~/Content/styles.css",
                    "~/Content/media.css",
                    "~/Content/fonts.css"
                    ));
        }
    }
}