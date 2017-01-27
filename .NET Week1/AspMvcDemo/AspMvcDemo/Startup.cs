using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspMvcDemo.Startup))]
namespace AspMvcDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
