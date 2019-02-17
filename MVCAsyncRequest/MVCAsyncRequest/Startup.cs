using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAsyncRequest.Startup))]
namespace MVCAsyncRequest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
