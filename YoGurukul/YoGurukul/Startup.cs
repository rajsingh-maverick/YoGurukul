using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YoGurukul.Startup))]
namespace YoGurukul
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
