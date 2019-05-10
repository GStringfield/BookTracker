using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookTracker.MVC.Startup))]
namespace BookTracker.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
