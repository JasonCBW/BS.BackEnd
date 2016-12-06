using System.Web;
using System.Web.Optimization;

namespace BS.BackEnd
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Areas/WebAdmin
            bundles.Add(new StyleBundle("~/Areas/WebAdmin/Content/css").Include(
                      "~/Areas/WebAdmin/Content/bootstrap.min.css",
                      "~/Areas/WebAdmin/Content/bootstrap-reset.css",
                      "~/Areas/WebAdmin/Content/font-awesome.css",
                      "~/Areas/WebAdmin/Content/gallery.css",
                      "~/Areas/WebAdmin/Content/style.css"));

            bundles.Add(new ScriptBundle("~/Areas/WebAdmin/bundles/BeginJs").Include(
                        "~/Areas/WebAdmin/Scripts/jquery-1.11.1.min.js",
                        "~/Areas/WebAdmin/Scripts/bootstrap.min.js",
                        "~/Areas/WebAdmin/Scripts/jquery.dcjqaccordion.2.7.js",
                        "~/Areas/WebAdmin/Scripts/jquery.scrollTo.min.js",
                        "~/Areas/WebAdmin/Scripts/jquery.nicescroll.js",
                        "~/Areas/WebAdmin/Scripts/respond.min.js",
                        "~/Areas/WebAdmin/Scripts/jquery.sparkline.js",
                        "~/Areas/WebAdmin/Scripts/sparkline-chart.js",
                        "~/Areas/WebAdmin/Scripts/common-scripts.js",
                        "~/Areas/WebAdmin/Scripts/count.js",
                        "~/Areas/WebAdmin/Scripts/editable-table.js"
                        )); 
  
            bundles.Add(new ScriptBundle("~/bundles/Vue").Include(
                      "~/Scripts/vue.js"));


            //BS.BackEnd
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
