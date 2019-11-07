using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SameDayServicezFinal.Startup))]
namespace SameDayServicezFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
