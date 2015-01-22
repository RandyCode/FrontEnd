using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FrontendCore.HttpModules
{
    public class ApplicationModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            // <add name="AppMod" type="FrontendCore.HttpModules.ApplicationModule,FrontendCore" />

        }

        public void Dispose() { 
        
        }

    }
}
