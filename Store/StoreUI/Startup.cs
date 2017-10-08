using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreUI.Startup))]
namespace StoreUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
