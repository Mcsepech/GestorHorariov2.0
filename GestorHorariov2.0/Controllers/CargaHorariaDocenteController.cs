using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorHorariov2._0.Models;

namespace GestorHorariov2._0.Controllers
{
    public class CargaHorariaDocenteController : Controller
    {
        public Docente objDocente = new Docente();
        public Ambiente objAmbiente = new Ambiente();
        CargaHorariaDocente objCargaHorariaDocente = new CargaHorariaDocente();
        public CargaDocenteCicloCurso objCargaDocenteCicloCurso = new CargaDocenteCicloCurso();
        public Dia objDia = new Dia();
        public Ciclo objCiclo = new Ciclo();
        public HoraEntrada objHoraEntrada = new HoraEntrada();
        public HoraSalida objHoraSalida = new HoraSalida();
        private int horaPedagocia = 0;

        private CargaHorariaDocente objCargaHoraria = new CargaHorariaDocente();
        // GET: Docente
        public ActionResult Index()

        {
            return View(objCargaHoraria.Listar());
        }
        public ActionResult Visualizar(int id)
        {
            return View(objCargaHoraria.obtener(id));
        }

        public ActionResult DetalleCurso(int id)
        {
            string ciclo = "";
            //ViewBag.curso_ciclo = objCargaDocenteCicloCurso.obtener(id);
            ViewBag.Dia = objDia.Listar();
            ViewBag.HoraEntrada = objHoraEntrada.Listar();
            ViewBag.HoraSalida = objHoraSalida.Listar();
            ViewBag.Ambiente = objAmbiente.Listar();
            /*ViewBag.NombreCiclo = objCargaDocenteCicloCurso.obtener2(id);*/
            if (id == 1) { ciclo = "Ciclo I"; }
            else if (id == 2) { ciclo = "Ciclo II"; }
            else if (id == 3) { ciclo = "Ciclo III"; }
            else if (id == 4) { ciclo = "Ciclo IV"; }
            else if (id == 5) { ciclo = "Ciclo V"; }
            else if (id == 6) { ciclo = "Ciclo VI"; }
            else if (id == 7) { ciclo = "Ciclo VII"; }
            else if (id == 8) { ciclo = "Ciclo VIII"; }
            else if (id == 9) { ciclo = "Ciclo IX"; }
            else if (id == 10) { ciclo = "Ciclo X"; }
            ViewBag.Ciclo = ciclo;
            return View(objCargaDocenteCicloCurso.obtener(id));
        }

        public ActionResult ObtenerCursos()
        {
            return View();
        }
        public ActionResult VerHorario()
        {
            return View();
        }

        public ActionResult _Horario(string codigo)
        {
            /*solo busqueda*/
            string lunes = "Lunes";
            string martes = "Martes";
            string miercoles = "Miercoles";
            string jueves = "Jueves";
            string viernes = "Viernes";
            string sabado = "Sabado";
            if (codigo == null)
            {
                return RedirectToAction("VerCursos");
            }
            else
            {
                ViewBag.Lunes = objCargaHorariaDocente.obtenerHorariosDocente(codigo, lunes);
                ViewBag.Martes = objCargaHorariaDocente.obtenerHorariosDocente(codigo, martes);
                ViewBag.Miercoles = objCargaHorariaDocente.obtenerHorariosDocente(codigo, miercoles);
                ViewBag.Jueves = objCargaHorariaDocente.obtenerHorariosDocente(codigo, jueves);
                ViewBag.Viernes = objCargaHorariaDocente.obtenerHorariosDocente(codigo, viernes);
                ViewBag.Sabado = objCargaHorariaDocente.obtenerHorariosDocente(codigo, sabado);
                ViewBag.Horas = objHoraEntrada.Listar();
                return View();
            }
        }

        public ActionResult _Horario2(string codigo)
        {
            /*solo busqueda*/
            string lunes = "Lunes";
            string martes = "Martes";
            string miercoles = "Miercoles";
            string jueves = "Jueves";
            string viernes = "Viernes";
            string sabado = "Sabado";
            if (codigo == null)
            {
                return RedirectToAction("VerCursos");
            }
            else
            {
                ViewBag.Lunes = objCargaHorariaDocente.obtenerHorariosDocente(codigo, lunes);
                ViewBag.Martes = objCargaHorariaDocente.obtenerHorariosDocente(codigo, martes);
                ViewBag.Miercoles = objCargaHorariaDocente.obtenerHorariosDocente(codigo, miercoles);
                ViewBag.Jueves = objCargaHorariaDocente.obtenerHorariosDocente(codigo, jueves);
                ViewBag.Viernes = objCargaHorariaDocente.obtenerHorariosDocente(codigo, viernes);
                ViewBag.Sabado = objCargaHorariaDocente.obtenerHorariosDocente(codigo, sabado);
                ViewBag.Horas = objHoraEntrada.Listar();
                ViewBag.CursosxCiclo = objCargaDocenteCicloCurso.obtener2(codigo);
                return View();
            }
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Dia = objDia.Listar();
            ViewBag.HoraEntrada = objHoraEntrada.Listar();
            ViewBag.HoraSalida = objHoraSalida.Listar();
            ViewBag.Ambiente = objAmbiente.Listar();
            ViewBag.Docente = objDocente.Listar();
            ViewBag.Ciclo = objCiclo.Listar();
            ViewBag.CargaDocenteCicloCurso = objCargaDocenteCicloCurso.Listar();
            return View(id == 0 ? new CargaHorariaDocente() /*Agrega un nuevo objeto*/
                : objCargaHoraria.obtener(id) /*Devuelve un objeto*/);
        }

        public ActionResult Guardar(/*CargaHorariaDocente objCargaHoraria*/ int carga_id, int ambiente_id, int entrada_id, int salida_id, int dia_id, string carga_estado/*, TimeSpan hora_entrada, TimeSpan hora_salida*/)
        {
            objCargaHoraria.carga_id = carga_id;
            objCargaHoraria.ambiente_id = ambiente_id;
            objCargaHoraria.entrada_id = entrada_id;
            objCargaHoraria.salida_id = salida_id;
            objCargaHoraria.carga_estado = carga_estado;

            /*imeSpan resta = hora_salida.Subtract(hora_salida);*/

            /*if(resta.Equals("01:00:00"))
            {

            }*/

            if (ModelState.IsValid)
            {
                objCargaHoraria.Guardar();
                return Redirect("~/CargaHorariaDocente/"/* + resta*/);
            }
            else
            {
                return View("~/Views/CargaHorariaDocente/AgregarEditar.cshtml");
            }
        }

        public ActionResult GuardarCurso(int carga_id, int ambiente_id, int entrada_id, int salida_id, int dia_id, string carga_estado, TimeSpan hora_entrada, TimeSpan hora_salida, int hora_ocu, int hora_lib)
        {
            objCargaHoraria.carga_id = carga_id;
            objCargaHoraria.ambiente_id = ambiente_id;
            objCargaHoraria.entrada_id = entrada_id;
            objCargaHoraria.salida_id = salida_id;
            objCargaHoraria.dia_id = dia_id;
            objCargaHoraria.carga_estado = carga_estado;

            DateTime fechaInicio = new DateTime();
            fechaInicio = DateTime.Parse(hora_entrada.ToString());

            DateTime fechaLlegada = new DateTime();
            fechaLlegada = DateTime.Parse(hora_salida.ToString());


            TimeSpan diferenciaHoras = new TimeSpan();
            diferenciaHoras = fechaLlegada - fechaInicio;



            if (diferenciaHoras.ToString() == "00:50:00")
            {
                horaPedagocia = horaPedagocia + 1;
            }
            else if (diferenciaHoras.ToString() == "01:40:00")
            {
                horaPedagocia = horaPedagocia + 2;
            }
            else if (diferenciaHoras.ToString() == "02:30:00")
            {
                horaPedagocia = horaPedagocia + 3;
            }
            else if (diferenciaHoras.ToString() == "03:20:00")
            {
                horaPedagocia = horaPedagocia + 4;
            }
            else if (diferenciaHoras.ToString() == "04:10:00")
            {
                horaPedagocia = horaPedagocia + 5;
            }
            else if (diferenciaHoras.ToString() == "05:00:00")
            {
                horaPedagocia = horaPedagocia + 6;
            }
            else
            {
                return Redirect("~/CargaDocenteCicloCurso/VerCursos");
            }

            if (hora_lib >= horaPedagocia)
            {
                if (ModelState.IsValid)
                {
                    int nue_hora_lib = hora_lib - horaPedagocia;
                    int nue_hora_ocu = hora_ocu + horaPedagocia;

                    var cargaDoc_horas = new CargaDocenteCicloCurso() { carga_id = carga_id, hora_lib = nue_hora_lib, hora_ocu = nue_hora_ocu };
                    using (var db = new modeloEscuela())
                    {
                        db.CargaDocenteCicloCurso.Attach(cargaDoc_horas);
                        db.Entry(cargaDoc_horas).Property(x => x.hora_lib).IsModified = true;
                        db.Entry(cargaDoc_horas).Property(x => x.hora_ocu).IsModified = true;
                        db.SaveChanges();
                    }

                    objCargaHoraria.GuardarCurso();
                    return Redirect("~/CargaDocenteCicloCurso/VerCursos");
                }
                else
                {
                    return View("~/Views/CargaDocenteCicloCurso/VerCursos.cshtml");
                }
            }
            else
            {
                return View("~/Views/CargaDocenteCicloCurso/VerCursos");
            }

        }

        public ActionResult Eliminar(int cargaDo_id, TimeSpan hora_entrada, TimeSpan hora_salida, int hora_ocu, int hora_lib, int carga_id)
        {

            objCargaHoraria.cargaDo_id = cargaDo_id;

            DateTime fechaInicio = new DateTime();
            fechaInicio = DateTime.Parse(hora_entrada.ToString());

            DateTime fechaLlegada = new DateTime();
            fechaLlegada = DateTime.Parse(hora_salida.ToString());


            TimeSpan diferenciaHoras = new TimeSpan();
            diferenciaHoras = fechaLlegada - fechaInicio;


            if (diferenciaHoras.ToString() == "00:50:00")
            {
                horaPedagocia = horaPedagocia + 1;
            }
            else if (diferenciaHoras.ToString() == "01:40:00")
            {
                horaPedagocia = horaPedagocia + 2;
            }
            else if (diferenciaHoras.ToString() == "02:30:00")
            {
                horaPedagocia = horaPedagocia + 3;
            }
            else if (diferenciaHoras.ToString() == "03:20:00")
            {
                horaPedagocia = horaPedagocia + 4;
            }
            else if (diferenciaHoras.ToString() == "04:10:00")
            {
                horaPedagocia = horaPedagocia + 5;
            }
            else if (diferenciaHoras.ToString() == "05:00:00")
            {
                horaPedagocia = horaPedagocia + 6;
            }
            else
            {

            }

            if (hora_lib <= horaPedagocia)
            {
                if (ModelState.IsValid)
                {
                    int nue_hora_lib = hora_lib + horaPedagocia;
                    int nue_hora_ocu = hora_ocu - horaPedagocia;

                    var cargaDoc_horas = new CargaDocenteCicloCurso() { carga_id = carga_id, hora_lib = nue_hora_lib, hora_ocu = nue_hora_ocu };
                    using (var db = new modeloEscuela())
                    {
                        db.CargaDocenteCicloCurso.Attach(cargaDoc_horas);
                        db.Entry(cargaDoc_horas).Property(x => x.hora_lib).IsModified = true;
                        db.Entry(cargaDoc_horas).Property(x => x.hora_ocu).IsModified = true;
                        db.SaveChanges();
                    }

                }
            }
            objCargaHoraria.Eliminar();

            return Redirect("~/CargaHorariaDocente");

        }

        public ActionResult indexBusqueda()
        {
            return View();
        }

        public ActionResult visualizarDocente(string buscarPor, string codigo)
        {
            if (buscarPor != null && codigo != null)
            {
                string lunes = "Lunes";
                string martes = "Martes";
                string miercoles = "Miercoles";
                string jueves = "Jueves";
                string viernes = "Viernes";
                string sabado = "Sabado";
                if (codigo == null)
                {
                    return RedirectToAction("indexBusqueda");
                }
                else
                {
                    ViewBag.Lunes = objCargaHorariaDocente.obtenerHorarios(buscarPor, codigo, lunes);
                    ViewBag.Martes = objCargaHorariaDocente.obtenerHorarios(buscarPor, codigo, martes);
                    ViewBag.Miercoles = objCargaHorariaDocente.obtenerHorarios(buscarPor, codigo, miercoles);
                    ViewBag.Jueves = objCargaHorariaDocente.obtenerHorarios(buscarPor, codigo, jueves);
                    ViewBag.Viernes = objCargaHorariaDocente.obtenerHorarios(buscarPor, codigo, viernes);
                    ViewBag.Sabado = objCargaHorariaDocente.obtenerHorarios(buscarPor, codigo, sabado);
                    ViewBag.Horas = objHoraEntrada.Listar();
                    return View();
                }
            }
            else if (buscarPor == null || codigo == null)
            {
                return RedirectToAction("indexBusqueda");
            }
            else
            {
                return RedirectToAction("indexBusqueda");
            }
        }
    }
}