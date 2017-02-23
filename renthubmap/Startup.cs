using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(renthubmap.Startup))]
namespace renthubmap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
