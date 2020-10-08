using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaOrdemPedidos.Startup))]
namespace SistemaOrdemPedidos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
