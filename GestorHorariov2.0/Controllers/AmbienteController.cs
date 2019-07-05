using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class AmbienteController : Controller
    {
        //TODO: Instanciar Semestre
        private Ambiente objAmbiente = new Ambiente();
        // GET: Semestre
        public ActionResult Index()
        {

            return View(objAmbiente.Listar());
        }

        //Ación Visualizar
        public ActionResult Visualizar(int id)
        {

            return View(objAmbiente.obtener(id));
        }

        // Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Ambiente() // Agrega un nuevo objeto
                : objAmbiente.obtener(id)); // Devuelve un objeto
        }

        //Acion Guardar
        public ActionResult Guardar(Ambiente objAmbiente)
        {
            if (ModelState.IsValid)
            {
                objAmbiente.Guardar();
                return Redirect("~/Ambiente");
            }
            else
            {
                return View("~/Views/Ambiente/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar
        public ActionResult Eliminar(int id)
        {
            objAmbiente.ambiente_id = id;
            objAmbiente.Eliminar();
            return Redirect("~/Ambiente");
        }
    }
}