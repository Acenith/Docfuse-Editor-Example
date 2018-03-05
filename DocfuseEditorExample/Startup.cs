using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DocfuseEditorExample.Startup))]
namespace DocfuseEditorExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
