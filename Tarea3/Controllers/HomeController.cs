using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tarea3.Models;
namespace Tarea3.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public ActionResult Index()
        {
            if (Request["nombreUsuario"] != null)
            {
                string userName = Request["nombreUsuario"];
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
        public string placeToken(string matrizString)
        {
            Debug.WriteLine("Matriz frente: " + matrizString);
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string UserName = ticket.Name; //You have the UserName!
            Debug.WriteLine("Decripted username: " + UserName);
            try
            {
                ServiceReference2.TikTakToePortClient client = Session["test"] as ServiceReference2.TikTakToePortClient;
                string tab = client.placeToken(matrizString);
                Debug.WriteLine("Recibido de wsdl: "+tab);
                return tab;
            }
            catch
            {
                ServiceReference2.TikTakToePortClient client = Session["test"] as ServiceReference2.TikTakToePortClient;
                string tab = client.placeToken(matrizString);
                Debug.WriteLine("Recibido de wsdl: " + tab);
                return tab;

            }
        }

    }
}