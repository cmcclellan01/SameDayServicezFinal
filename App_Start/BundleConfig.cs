using System.Web;
using System.Web.Optimization;

namespace SameDayServicezFinal
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryT").Include(
                         "~/Scripts/jquery-3.4.1.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/umd/popper.js", 
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/utilities").Include(                      
                        "~/Scripts/utilities.js"));


            bundles.Add(new ScriptBundle("~/bundles/DropZone").Include(
                        "~/Scripts/dropzone/dropzone.min.js" ));

            bundles.Add(new ScriptBundle("~/bundles/Datatables").Include(
                         "~/Scripts/DataTables/media/js/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/extensions/Responsive/js/dataTables.responsive.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/portal").Include(                       
                        "~/Scripts/bootstrap-checkbox.js",                       
                        "~/Scripts/profile.js",
                        "~/Scripts/summernote-bs4.js",
                        "~/Scripts/sweetalert.js",
                        "~/Scripts/jquery.loading.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/Content/fontawesome-all.css"
                ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                              "~/Content/themes/base/jquery-ui-min.css",
                              "~/Scripts/dropzone/dropzone.min.css",
                              "~/Content/themes/base/datepicker.css",
                              "~/Content/DataTables/media/css/dataTables.bootstrap4.min.css",
                              "~/Content/DataTables/extensions/Responsive/css/responsive.bootstrap4.min.css",
                              "~/Content/bootstrap.css",
                              "~/Content/sweetalert.cs",
                              "~/Content/loading.css",         
                              "~/Content/site.css", 
                              "~/Content/theme.css", 
                              "~/Content/custom.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
