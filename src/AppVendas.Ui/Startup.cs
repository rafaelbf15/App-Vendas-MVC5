using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppVendas.Ui.Startup))]
namespace AppVendas.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
