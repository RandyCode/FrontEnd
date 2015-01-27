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
        public static string Root { get; private set; }

        public void Init(HttpApplication context)
        {
            if (Root == null)
            {
                Root = AppDomain.CurrentDomain.BaseDirectory;
                AreaRegistration.RegisterAllAreas();
                RouteTable.Routes.MapRoute("All", "{controller}/{action}", new { controller = "Home", action = "index" }, new string[] { "FrontendCore" });
                //RouteTable.Routes.MapRoute("Article", "Article/View/{file}", new { controller = "Article", action = "View" }, new string[] { "EgoalTech.Travel.Web" });
                //ModelBinders.Binders.Add(typeof(string), new StringTrimModelBinder());
                //FluentValidationModelValidatorProvider.Configure();
            }
            context.PreSendRequestHeaders += (sender, e) =>
            {
                var headers = HttpContext.Current.Response.Headers;
                headers.Remove("X-AspNet-Version");
                headers.Remove("X-AspNetMvc-Version");
                headers.Remove("X-Powered-By");
                headers.Remove("X-SourceFiles");
                headers.Add("Access-Control-Allow-Origin", "*");
            };
        }

        public void Dispose() { 
        
        }

    }
}
