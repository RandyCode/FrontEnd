using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using FrontendCore.Models;
using Randy.Memcached;
using FrontendCore.Cache;
using FrontendCore.Utilities;

namespace FrontendCore
{
    public class BaseController : Controller
    {

        public ICache Cache { get; set; }


        protected string GetCookie(string key)
        {
            var cookie = HttpContext.Request.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return null;
        }

        protected void SetCookie(string key, string value, DateTime timeout)
        {
            var cookie = HttpContext.Response.Cookies[key];
            if (cookie == null)
            {
                cookie = new HttpCookie(key, value);
                cookie.Expires = timeout;
                HttpContext.Response.AppendCookie(cookie);
            }
            else
            {
                cookie.Value = value;
                cookie.Expires = timeout;
                HttpContext.Response.SetCookie(cookie);
            }

        }

        public BaseController() 
        {
            Cache = Tools.DistrubutedCache;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            ErrorModel model = new ErrorModel();
            model.Message = filterContext.Exception.Message;
            model.Target = filterContext.Exception.TargetSite.ToString();
            filterContext.Result = View("~/Views/Exception/base.cshtml", model);

        }


    }
}
