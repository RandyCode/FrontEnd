
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml;
using System.Net.NetworkInformation;
using System.Net;
using System.Web;



namespace FrontendCore
{
    public class HomeController:BaseController
    {
        public ViewResult index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Login()
        { return View(); }

        [HttpPost]
        public JsonResult Login(string email,string pwd)  //json 格式不能传null
        {
            //Session["User"] = string.Format("{0},{1}", email, pwd);
            //SetCookie("User", email, DateTime.Now.AddDays(1));
            //Cache.Store("User", email + pwd);
 
            return Json("randy"); 
        }

        public JsonResult SignOut()
        {
            //Cache.Remove("User");
            return Json("randy");
        }

        //OutputCache不需要手动指定VaryByParam，会自动使用Action的参数作为缓存过期条件 , VaryByParam = "none"
        //[OutputCache(Duration = 5, Location = OutputCacheLocation.Client, NoStore = true)]  页面缓存 (局部缓存：做成模板页 ，刷新子页面）
        public ViewResult FirstPage()
        {          
            //var ss = Dns.GetHostAddresses(Dns.GetHostName());
            return View();
        }
    }
}
