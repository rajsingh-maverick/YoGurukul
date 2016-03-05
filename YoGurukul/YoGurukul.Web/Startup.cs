using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YoGurukul.Web.Startup))]
namespace YoGurukul.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
