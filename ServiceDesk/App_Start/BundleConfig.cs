using System.Web;
using System.Web.Optimization;

namespace ServiceDesk
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/admin-lte/css").Include(
                      "~/admin-lte/css/AdminLTE.css",
                      "~/admin-lte/css/skins/skin-red.css",
                      "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                      "~/admin-lte/bower_components/bootstrap/dist/css/bootstrap.min.css",
                      "~/admin-lte/bower_components/font-awesome/css/font-awesome.min.css",
                       "~/admin-lte/bower_components/Ionicons/css/ionicons.min.css",
                       "~/admin-lte/bower_components/fullcalendar/dist/fullcalendar.min.css",
                       "~/admin-lte/bower_components/fullcalendar/dist/fullcalendar.print.min.css",
                       "~/admin-lte/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css",
                       "~/admin-lte/bower_components/jvectormap/jquery-jvectormap.css"));

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                      "~/admin-lte/js/adminlte.js",
                      "~/admin-lte/bower_components/jquery/dist/jquery.min.js",
                      "~/admin-lte/bower_components/jquery-ui/jquery-ui.min.js",
                      "~/admin-lte/plugins/fastclick/fastclick.js",
                      "~/admin-lte/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                      "~/admin-lte/plugins/Chart.js/Chart.js",
                      "~/admin-lte/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                      "~/admin-lte/bower_components/fastclick/lib/fastclick.js",
                      "~/admin-lte/bower_components/moment/moment.js",
                      "~/admin-lte/bower_components/fullcalendar/dist/fullcalendar.min.js",
                      "~/admin-lte/bower_components/bootstrap/dist/js/bootstrap.min.js",
                      "~/admin-lte/bower_components/Chart.js/Chart.js",
                      "~/admin-lte/bower_components/datatables.net/js/jquery.dataTables.min.js",
                      "~/admin-lte/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js",
                      "~/admin-lte/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js",
                      "~/admin-lte/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                      "~/admin-lte/plugins/jvectormap/jquery-jvectormap-world-mill-en.js"
                      ));

        }
    }
}
