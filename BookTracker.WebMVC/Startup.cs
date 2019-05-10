using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookTracker.WebMVC.Startup))]
namespace BookTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
