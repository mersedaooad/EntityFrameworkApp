using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KucniBudzetEntity.Startup))]
namespace KucniBudzetEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
