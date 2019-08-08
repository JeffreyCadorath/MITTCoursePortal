using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MITTCourseAppWTests.Startup))]
namespace MITTCourseAppWTests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
