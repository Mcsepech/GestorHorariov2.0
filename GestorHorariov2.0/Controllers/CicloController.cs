using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class CicloController : Controller
    {
        private Ciclo objCiclo = new Ciclo();
        // GET: Docente
        public ActionResult Index()

        {
            return View(objCiclo.Listar());
        }
        public ActionResult Visualizar(int id)
        {
            return View(objCiclo.obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Ciclo() /*Agrega un nuevo objeto*/
                : objCiclo.obtener(id) /*Devuelve un objeto*/);
        }

        public ActionResult Guardar(Ciclo objCiclo)
        {
            if (ModelState.IsValid)
            {
                objCiclo.Guardar();
                return Redirect("~/Ciclo");
            }
            else
            {
                return View("~/Views/Ciclo/AgregarEditar.cshtml");
            }
        }

        public ActionResult Eliminar(int id)
        {
            objCiclo.ciclo_id = id;
            objCiclo.Eliminar();

            return Redirect("~/Ciclo");
        }
    }
}