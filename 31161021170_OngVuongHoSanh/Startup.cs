using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_31161021170_OngVuongHoSanh.Startup))]
namespace _31161021170_OngVuongHoSanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
