using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseAndResultMS.Startup))]
namespace CourseAndResultMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
