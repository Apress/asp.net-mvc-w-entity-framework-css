using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeFirstExistingDB.Startup))]
namespace CodeFirstExistingDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
