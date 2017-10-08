using System.Web;
using System.Web.Optimization;

namespace Store.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-1.10.2.min.js", 
                        "~/Scripts/jquery-ui-1.11.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.validate-vsdoc.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                        "~/Scripts/custom/datepicker.js"));
           
            bundles.Add(new ScriptBundle("~/bundles/parsedate").Include(
                       "~/Scripts/custom/parsedate.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
           
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            // Styles

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/bootstrapmodern.css"));
            
            bundles.Add(new StyleBundle("~/Content/bootswatch").Include(
                       "~/Content/bootswatch/spacelab/bootstrap.min.css",
                     "~/Content/site.css",
                     "~/Content/bootstrapmodern.css"));
            
            bundles.Add(new StyleBundle("~/Content/themes/base/css")
                .IncludeDirectory("~/Content/themes/base", "*.css", true));


            
        }
    }
}
