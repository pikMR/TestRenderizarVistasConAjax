using AppDynamicRenderViewAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AppDynamicRenderViewAjax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NumberViewModel modelo = new NumberViewModel();
            modelo.renderId = 0;
            return View(modelo);
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

        [HttpGet]
        public ActionResult RenderizarNumeroSiguiente(int numeroActual = 0)
        {
            NumberViewModel modelo = new NumberViewModel();
            modelo.renderId = numeroActual + 1;
            return PartialView("_Number",modelo);
        }


    }
}