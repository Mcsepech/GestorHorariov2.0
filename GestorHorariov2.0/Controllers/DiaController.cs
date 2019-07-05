using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class DiaController : Controller
    {
        private Dia objDia = new Dia();
        // GET: Docente
        public ActionResult Index()

        {
            return View(objDia.Listar());
        }
        public ActionResult Visualizar(int id)
        {
            return View(objDia.obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Dia() /*Agrega un nuevo objeto*/
                : objDia.obtener(id) /*Devuelve un objeto*/);
        }

        public ActionResult Guardar(Dia objDia)
        {
            if (ModelState.IsValid)
            {
                objDia.Guardar();
                return Redirect("~/Dia");
            }
            else
            {
                return View("~/Views/Dia/AgregarEditar.cshtml");
            }
        }

        public ActionResult Eliminar(int id)
        {
            objDia.dia_id = id;
            objDia.Eliminar();

            return Redirect("~/Dia");
        }
    }
}