using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Tarea3.Controllers
{
    public class HomeController : Controller
    {
        public ServiceReference2.TikTakToePortClient client;
        public HomeController()
        {
            client = new ServiceReference2.TikTakToePortClient();
        }
        public ActionResult Index()
        {
            if (Request["nombreUsuario"] != null)
            {
                string userName = Request["nombreUsuario"];
                Debug.WriteLine(userName);
                ViewBag.needsAuth =false;
                FormsAuthentication.SetAuthCookie(userName, false);
                return View();
            }
            else
            {
                ViewBag.needsAuth = true;
                return View();
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void placeToken(string token, string id)
        {
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name; //You have the UserName!
            Debug.WriteLine("Decripted username: " + UserName);
            int row = id[0] - '0';
            int col = id[1] - '0';
            //string tab = client.placeToken(token, row, col);
            //Debug.WriteLine(tab);
            try
            {
                string tab = client.placeToken(token, row, col);
                Debug.WriteLine(tab);
            }
            catch
            {
                string tab = client.placeToken(token, row, col);
                Debug.WriteLine(tab);

            }
        }

    }
}