using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetFleeks.Startup))]
namespace NetFleeks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
