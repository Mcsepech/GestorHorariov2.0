using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class CursoController : Controller
    {
        private Curso objCurso = new Curso();
        // GET: Curso
        public ActionResult Index()
        {
            return View(objCurso.Listar());
        }
        //Ación Visualizar
        public ActionResult Visualizar(int id)
        {

            return View(objCurso.obtener(id));
        }

        // Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Curso() // Agrega un nuevo objeto
                : objCurso.obtener(id)); // Devuelve un objeto
        }

        //Acion Guardar
        public ActionResult Guardar(Curso objCurso)
        {
            if (ModelState.IsValid)
            {
                objCurso.Guardar();
                return Redirect("~/Curso");
            }
            else
            {
                return View("~/Views/Curso/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar
        public ActionResult Eliminar(int id)
        {
            objCurso.curso_id = id;
            objCurso.Eliminar();
            return Redirect("~/Curso");
        }
    }
}