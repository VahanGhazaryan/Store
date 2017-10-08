using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Store.UI.Startup))]
namespace Store.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
