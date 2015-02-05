using System.Net.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendCore
{
    public class HubModule : HubPipelineModule
    {
        protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
        {
            base.OnIncomingError(exceptionContext, invokerContext);
        }


        protected override void OnAfterConnect(IHub hub)
        {
           
            base.OnAfterConnect(hub);
        }

    }
}
