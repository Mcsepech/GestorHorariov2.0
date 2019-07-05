using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class HoraEntradaController : Controller
    {
        private HoraEntrada objHoraEntrada = new HoraEntrada();
        // GET: Docente
        public ActionResult Index()

        {
            return View(objHoraEntrada.Listar());
        }
        public ActionResult Visualizar(int id)
        {
            return View(objHoraEntrada.obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new HoraEntrada() /*Agrega un nuevo objeto*/
                : objHoraEntrada.obtener(id) /*Devuelve un objeto*/);
        }

        public ActionResult Guardar(HoraEntrada objHoraEntrada)
        {
            if (ModelState.IsValid)
            {
                objHoraEntrada.Guardar();
                return Redirect("~/HoraEntrada");
            }
            else
            {
                return View("~/Views/HoraEntrada/AgregarEditar.cshtml");
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHoraEntrada.entrada_id = id;
            objHoraEntrada.Eliminar();

            return Redirect("~/HoraEntrada");
        }
    }
}