using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KMDIDailyHealthProfile.Startup))]
namespace KMDIDailyHealthProfile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
