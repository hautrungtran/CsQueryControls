using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CsQueryControls.Example.Startup))]
namespace CsQueryControls.Example
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
