using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalMgtSystem.Startup))]
namespace HospitalMgtSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
