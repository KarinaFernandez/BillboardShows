using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Espectaculos.Startup))]
namespace Espectaculos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
