using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(egdBooking_v2.Startup))]
namespace egdBooking_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
