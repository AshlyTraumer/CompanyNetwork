using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyNetwork.Startup))]
namespace CompanyNetwork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
