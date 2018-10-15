using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamify.Startup))]
namespace Gamify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
