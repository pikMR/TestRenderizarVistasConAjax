using AppDynamicRenderViewAjax.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

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

        // GET: Home  
        [HttpGet]
        public ActionResult Employees()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Dropdown()
        {
            return View();
        }

        /*
         * Función que permite pasar json para tratar con JQUERY, no es una solución para renderizar.
         
        [HttpPost]
        public JsonResult Employees(EmpModel obj)
        {
            ViewBag.Records = "Name : " + obj.Name + " City:  " + obj.City + " Addreess: " + obj.Address;
            System.Threading.Thread.Sleep(2000); // este sleep representa una llamada a un servicio.
            obj.CODIGO_POSTAL = "30009";
            return Json(obj);
        }
        */

        [HttpPost]
        public ActionResult Employees(EmpModel obj)
        {
            ViewBag.Records = "Name : " + obj.Name + " City:  " + obj.City + " Addreess: " + obj.Address;
            System.Threading.Thread.Sleep(2000); // este sleep representa una llamada a un servicio.
            obj.CODIGO_POSTAL = "30009";
            obj.City = "MURCIA";
            return PartialView("EmpPartialView",obj);
            //return Json(obj);
        }

        public PartialViewResult DataEmployees(string listselected)
        {
            var usuarios = new List<EmpModel>()
            {
                new EmpModel() { Address = "Calle Espatula",City = "Madrid",Name="Paco", CODIGO_POSTAL = "30009"},
                new EmpModel() { Address = "Calle Latifundio",City = "Jaen",Name="Juan",CODIGO_POSTAL = "30010"},
                new EmpModel() { Address = "Calle Segura",City = "Murcia",Name="Macario",CODIGO_POSTAL = "30011"}
            };

            var _selected = usuarios.FirstOrDefault(x => x.CODIGO_POSTAL.Equals(listselected));
            return PartialView("Form",_selected);
        }

        [HttpPost]
        public JsonResult DataEmployees(EmpModel data)
        {
            var usuarios = new List<EmpModel>()
            {
                new EmpModel() { Address = "Calle Espatula",City = "Madrid",Name="Paco", CODIGO_POSTAL = "30009"},
                new EmpModel() { Address = "Calle Latifundio",City = "Jaen",Name="Juan",CODIGO_POSTAL = "30010"},
                new EmpModel() { Address = "Calle Segura",City = "Murcia",Name="Macario",CODIGO_POSTAL = "30011"}
            };
            var _selected = usuarios.FirstOrDefault(x => x.City.Equals(data.City));
            return Json(_selected);
        }
    }
}