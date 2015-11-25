using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ContosoFinal.Startup))]
namespace ContosoFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
