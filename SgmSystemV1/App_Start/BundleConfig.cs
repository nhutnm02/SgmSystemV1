using System.Web;
using System.Web.Optimization;

namespace SgmSystemV1
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                     "~/Content/bootstrap.min.css",
                    "~/Content/metisMenu.min.css",
                    "~/Content/admin/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css",
                    "~/Content/admin/bower_components/datatables-responsive/css/dataTables.responsive.css",
                    "~/Content/sb-admin-2.css",
                    "~/Content/font-awesome.min.css"
                ));
           
            bundles.Add(new ScriptBundle("~/bundles/scriptTable").Include(
                    "~/Content/admin/bower_components/datatables/media/js/jquery.dataTables.min.js",
                    "~/Content/admin/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"
                ));
        }
    }
}
