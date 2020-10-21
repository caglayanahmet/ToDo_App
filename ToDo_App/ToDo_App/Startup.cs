using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDo_App.Startup))]
namespace ToDo_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
