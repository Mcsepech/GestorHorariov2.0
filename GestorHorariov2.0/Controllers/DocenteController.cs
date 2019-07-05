using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;


namespace GestorHorariov2._0.Controllers
{
    public class DocenteController : Controller
    {
        private Docente objDocente = new Docente();
        // GET: Docente
        public ActionResult Index()

        {
            return View(objDocente.Listar());
        }
        public ActionResult Visualizar(int id)
        {
            return View(objDocente.obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Docente() /*Agrega un nuevo objeto*/
                : objDocente.obtener(id) /*Devuelve un objeto*/);
        }

        public ActionResult Guardar(Docente objDocente)
        {
            if (ModelState.IsValid)
            {
                objDocente.Guardar();
                return Redirect("~/Docente");
            }
            else
            {
                return View("~/Views/Docente/AgregarEditar.cshtml");
            }
        }

        public ActionResult Eliminar(int id)
        {
            objDocente.docente_id = id;
            objDocente.Eliminar();

            return Redirect("~/Docente");
        }
    }
}