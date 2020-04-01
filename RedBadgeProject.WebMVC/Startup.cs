using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RedBadgeProject.WebMVC.Startup))]
namespace RedBadgeProject.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
