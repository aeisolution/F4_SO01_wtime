using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wtime.Startup))]
namespace wtime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
