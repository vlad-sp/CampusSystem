using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CampusSystem.Web.Startup))]
namespace CampusSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
