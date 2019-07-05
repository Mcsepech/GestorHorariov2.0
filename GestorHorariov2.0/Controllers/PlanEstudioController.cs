using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class PlanEstudioController : Controller
    {
        private PlanEstudios objplanestudio = new PlanEstudios();
        // GET: PlanEstudio
        public ActionResult Index()
        {
            return View(objplanestudio.Listar());
        }
        //Ación Visualizar
        public ActionResult Visualizar(int id)
        {

            return View(objplanestudio.obtener(id));
        }

        // Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new PlanEstudios() // Agrega un nuevo objeto
                : objplanestudio.obtener(id)); // Devuelve un objeto
        }

        //Acion Guardar
        public ActionResult Guardar(PlanEstudios objplanestudio)
        {
            if (ModelState.IsValid)
            {
                objplanestudio.Guardar();
                return Redirect("~/PlanEstudios");
            }
            else
            {
                return View("~/Views/PlanEstudios/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar
        public ActionResult Eliminar(int id)
        {
            objplanestudio.plan_id = id;
            objplanestudio.Eliminar();
            return Redirect("~/PlanEstudios");
        }
    }
}
        