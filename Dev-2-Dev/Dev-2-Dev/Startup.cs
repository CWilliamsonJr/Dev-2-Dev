using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dev_2_Dev.Startup))]
namespace Dev_2_Dev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
