using System.Web;
using System.Web.Optimization;

namespace DocfuseEditorExample
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

            // Style bundle for Summernote editor
            bundles.Add(new StyleBundle("~/Styles/Summernote/Bundle")
                .IncludeDirectory("~/Styles/Summernote", "*.css", true));

            // Script bundle for Summernote editor
            bundles.Add(new ScriptBundle("~/Scripts/Summernote/Bundle")
                .IncludeDirectory("~/Scripts/Summernote", "*.js", true));

            // Implement editor script
            bundles.Add(new ScriptBundle("~/Editor")
                .Include("~/Scripts/Implement-editor.js"));
        }
    }
}
