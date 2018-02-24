using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab02_ED1.Startup))]
namespace Lab02_ED1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
