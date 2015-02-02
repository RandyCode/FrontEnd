using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(FrontendCore.OwinStartup))]

namespace FrontendCore
{
    public class OwinStartup
    {
        public void Configuration(Owin.IAppBuilder app)
        {
            //GlobalHost.HubPipeline.AddModule(new newModule());
            app.MapSignalR();
        }
    }
}
