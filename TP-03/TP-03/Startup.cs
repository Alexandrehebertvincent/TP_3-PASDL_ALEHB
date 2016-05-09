using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TP_03.Startup))]
namespace TP_03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
