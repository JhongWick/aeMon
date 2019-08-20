using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KPIAnalytics.Startup))]
namespace KPIAnalytics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
