using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_Commerce_Site.Startup))]
namespace E_Commerce_Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
