using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaProject.Startup))]
namespace CinemaProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
