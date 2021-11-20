using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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

        public string hello(string token, string id)
        {
            string tab=client.sendTableroClient();
            Debug.WriteLine(tab);
            return tab;

        }

    }
}