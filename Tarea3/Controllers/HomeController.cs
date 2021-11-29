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
        [HttpGet]
        public ActionResult Index()
        {
            if (Request["nombreUsuario"] != null)
            {
                //ViewBag.tiempoInicial= DateTime.Now;
                string userName = Request["nombreUsuario"];
                ViewBag.needsAuth =false;
                Debug.WriteLine(userName);
                FormsAuthentication.SetAuthCookie(userName, false);
                return View();
            }
            else
            {
                ViewBag.needsAuth = true;
                return View();
            }

        }
        [HttpPost]
        public ActionResult Index(string resultado)
        {
            Debug.WriteLine(resultado);
            if (resultado != "")
            {
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                string ganador = ticket.Name; //You have the UserName!
                SqlHandler handler = new SqlHandler();
                handler.InsertarEnBaseDeDatos(ganador,resultado);
            }
            return RedirectToAction("Index","Home");
        }
        public string placeToken(string matrizString)
        {
            Debug.WriteLine("Matriz frente: " + matrizString);
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

        public ActionResult getPuntajes()
        {
            SqlHandler handler = new SqlHandler();
            ViewBag.puntajes=handler.LeerBaseDeDatos();
            Debug.WriteLine(handler.LeerBaseDeDatos());
            return View();
        }

    }
}