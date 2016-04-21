using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IP3Project.Startup))]
namespace IP3Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
