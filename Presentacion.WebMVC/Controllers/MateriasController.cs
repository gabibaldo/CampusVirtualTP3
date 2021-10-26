using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.WebMVC.Controllers
{
    public class MateriasController : Controller
    {
        // GET: Materias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Negocio.Materia materia)
        {
            materia.Grabar();
            return RedirectToAction("Alta");
        }
    }
}