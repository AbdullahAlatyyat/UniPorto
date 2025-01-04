using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniPortoWebsite.Startup))]
namespace UniPortoWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
