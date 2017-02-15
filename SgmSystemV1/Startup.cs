using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SgmSystemV1.Startup))]
namespace SgmSystemV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
