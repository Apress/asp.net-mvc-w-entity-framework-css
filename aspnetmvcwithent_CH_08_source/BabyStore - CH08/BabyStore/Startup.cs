using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BabyStore.Startup))]
namespace BabyStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
