using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class CargaDocenteCicloCursoController : Controller
    {
        private CargaDocenteCicloCurso cargadoc = new CargaDocenteCicloCurso();
        private Ciclo ciclo = new Ciclo();

        // GET: CargaDocenteCicloCurso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Horas(int carga_id = 0)
        {
            return View("_Horas", cargadoc.listarHoras(carga_id));
        }

        //public JsonResult obtenerHoras(int id_carga)
        //{
        //    modeloEscuela db = new modeloEscuela();
        //    var carga = db.CargaDocenteCicloCurso.Where(e => e.carga_id == id_carga).SingleOrDefault();
        //    return new JsonResult { Data = carga, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        public ActionResult VerCursos()
        {
            string primero = "Ciclo I";
            string segundo = "Ciclo II";
            string tercero = "Ciclo III";
            string cuarto = "Ciclo IV";
            string quinto = "Ciclo V";
            string sexto = "Ciclo VI";
            string septimo = "Ciclo VII";
            string octavo = "Ciclo VIII";
            string noveno = "Ciclo IX";
            string decimo = "Ciclo X";
            ViewBag.ciclo1 = cargadoc.obtenerCursoCiclo(primero);
            ViewBag.ciclo2 = cargadoc.obtenerCursoCiclo(segundo);
            ViewBag.ciclo3 = cargadoc.obtenerCursoCiclo(tercero);
            ViewBag.ciclo4 = cargadoc.obtenerCursoCiclo(cuarto);
            ViewBag.ciclo5 = cargadoc.obtenerCursoCiclo(quinto);
            ViewBag.ciclo6 = cargadoc.obtenerCursoCiclo(sexto);
            ViewBag.ciclo7 = cargadoc.obtenerCursoCiclo(septimo);
            ViewBag.ciclo8 = cargadoc.obtenerCursoCiclo(octavo);
            ViewBag.ciclo9 = cargadoc.obtenerCursoCiclo(noveno);
            ViewBag.ciclo10 = cargadoc.obtenerCursoCiclo(decimo);

            ViewBag.Ciclo = ciclo.Listar();

            return View();
        }
    }
}