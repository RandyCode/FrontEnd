using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace FrontendCore.HttpHandlers
{
    public class ApplicationHandler : IHttpHandler, IRequiresSessionState  //for use session
    {
        public bool IsReusable
        {
            get { return true; }
        }
        //    <add name="imgHandler" path="img/*" verb="*" type="FrontendCore.HttpHandlers.ApplicationHandler,FrontendCore"/>
        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.Write("Application httpHandler");
        }
    }
}
