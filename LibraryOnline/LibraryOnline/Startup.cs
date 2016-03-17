using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryOnline.Startup))]
namespace LibraryOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
