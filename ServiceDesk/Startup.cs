using Microsoft.Owin;
using Owin;
using ServiceDesk.Models;

[assembly: OwinStartupAttribute(typeof(ServiceDesk.Startup))]
namespace ServiceDesk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.CreatePerOwinContext<ApplicationRoleManager>(Application‌​RoleManager.Create);
        }
    }
}
