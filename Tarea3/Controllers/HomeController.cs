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
        public ActionResult Index()
        {
            servicioBraulio.ECCI_HolaMundoPortClient cliente = new servicioBraulio.ECCI_HolaMundoPortClient();
            ViewBag.saludo = cliente.salude("Joseee");
            miServicio.ECCI_HolaMundoPortClient cliente2= new miServicio.ECCI_HolaMundoPortClient();
            string s2 = cliente2.salude("David");

            //Con url de Braulio en wsdl tira error de que no llega la info
            //Poniendo mi url: : 'Error al deserializar el cuerpo del mensaje de respuesta para la operación 'salude'. Fin de archivo no esperado. Los siguientes elementos no están cerrados: Envelope. Línea 2, posición 461.'
            //USando localHost:System.ServiceModel.ProtocolException: 'El tipo de contenido text/html; charset=UTF-8 del mensaje de respuesta no coincide con el tipo de contenido del enlace (text/xml; charset=utf-8). 
            string s = ViewBag.saludoLocal;
            
            Debug.WriteLine("Saludo de verdad: " + s2);
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
    }
}