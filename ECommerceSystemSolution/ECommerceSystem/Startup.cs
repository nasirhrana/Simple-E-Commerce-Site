using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECommerceSystem.Startup))]
namespace ECommerceSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
