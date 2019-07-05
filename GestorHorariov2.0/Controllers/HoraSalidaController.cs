using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class HoraSalidaController : Controller
    {
        private HoraSalida objHoraSalida = new HoraSalida();
        // GET: Docente
        public ActionResult Index()

        {
            return View(objHoraSalida.Listar());
        }
        public ActionResult Visualizar(int id)
        {
            return View(objHoraSalida.obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new HoraSalida() /*Agrega un nuevo objeto*/
                : objHoraSalida.obtener(id) /*Devuelve un objeto*/);
        }

        public ActionResult Guardar(HoraSalida objHoraSalida)
        {
            if (ModelState.IsValid)
            {
                objHoraSalida.Guardar();
                return Redirect("~/HoraSalida");
            }
            else
            {
                return View("~/Views/HoraSalida/AgregarEditar.cshtml");
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHoraSalida.salida_id = id;
            objHoraSalida.Eliminar();

            return Redirect("~/HoraSalida");
        }
    }
}