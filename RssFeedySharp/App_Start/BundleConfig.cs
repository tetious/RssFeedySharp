using System.Web;
using System.Web.Optimization;

namespace RssFeedySharp
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                        "~/Scripts/vendor/modernizr-*",
                        "~/Scripts/vendor/jquery-{version}.js",
                        "~/Scripts/vendor/jquery.unobtrusive*",
                        "~/Scripts/vendor/jquery.validate*",
                        "~/Scripts/vendor/jquery.layout.js",
                        "~/Scripts/vendor/bootstrap.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css", 
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}