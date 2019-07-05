namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("CargaHorariaDocente")]
    public partial class CargaHorariaDocente
    {
        [Key]
        public int cargaDo_id { get; set; }

        public int carga_id { get; set; }

        public int ambiente_id { get; set; }

        public int entrada_id { get; set; }

        public int salida_id { get; set; }

        public int dia_id { get; set; }

        [StringLength(1)]
        public string carga_estado { get; set; }

        public virtual Ambiente Ambiente { get; set; }

        public virtual CargaDocenteCicloCurso CargaDocenteCicloCurso { get; set; }

        public virtual Dia Dia { get; set; }

        public virtual HoraEntrada HoraEntrada { get; set; }

        public virtual HoraSalida HoraSalida { get; set; }



        public List<CargaHorariaDocente> obtenerHorarios(string buscarPor, string codigo, string dia)
        {
            if (buscarPor == "Docente")
            {
                modeloEscuela db = new modeloEscuela();
                var docente = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                                .Include(e => e.Ambiente)
                                                .Include(e => e.HoraEntrada)
                                                .Include(e => e.HoraSalida)
                                                .Include(e => e.CargaDocenteCicloCurso.Curso)
                                                .Include(e => e.CargaDocenteCicloCurso.Docente)
                                                .Where(e => e.CargaDocenteCicloCurso.Docente.docente_codigo == codigo)
                                                .Where(e => e.Dia.dia_nombre == dia);
                return docente.ToList();
            }
            else if (buscarPor == "Curso")
            {
                modeloEscuela db = new modeloEscuela();
                var curso = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                                .Include(e => e.Ambiente)
                                                .Include(e => e.HoraEntrada)
                                                .Include(e => e.HoraSalida)
                                                .Include(e => e.CargaDocenteCicloCurso.Curso)
                                                .Include(e => e.CargaDocenteCicloCurso.Docente)
                                                .Where(e => e.CargaDocenteCicloCurso.Curso.curso_nombre == codigo)
                                                .Where(e => e.Dia.dia_nombre == dia);
                return curso.ToList();
            }
            else if (buscarPor == "Ciclo")
            {
                modeloEscuela db = new modeloEscuela();
                var ciclo = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                                .Include(e => e.Ambiente)
                                                .Include(e => e.HoraEntrada)
                                                .Include(e => e.HoraSalida)
                                                .Include(e => e.CargaDocenteCicloCurso.Curso)
                                                .Include(e => e.CargaDocenteCicloCurso.Docente)
                                                .Where(e => e.CargaDocenteCicloCurso.Ciclo.ciclo_nombre == codigo)
                                                .Where(e => e.Dia.dia_nombre == dia);
                return ciclo.ToList();
            }
            else
            {
                modeloEscuela db = new modeloEscuela();
                var ciclo = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                                .Include(e => e.Ambiente)
                                                .Include(e => e.HoraEntrada)
                                                .Include(e => e.HoraSalida)
                                                .Include(e => e.CargaDocenteCicloCurso.Curso)
                                                .Include(e => e.CargaDocenteCicloCurso.Docente)
                                                .Where(e => e.Dia.dia_nombre == dia);
                return ciclo.ToList();
            }
        }



        public List<CargaHorariaDocente> obtenerHorariosDocente(string codigo, string dia)
        {
            modeloEscuela db = new modeloEscuela();
            var horas = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                            .Include(e => e.Ambiente)
                                            .Include(e => e.HoraEntrada)
                                            .Include(e => e.HoraSalida)
                                            .Include(e => e.CargaDocenteCicloCurso.Curso)
                                            .Include(e => e.CargaDocenteCicloCurso.Docente)
                                            .Include(e => e.Dia)
                                            .Where(e => e.CargaDocenteCicloCurso.Ciclo.ciclo_nombre == codigo)
                                            .Where(e => e.Dia.dia_nombre == dia);
            /*.GroupBy(e => e.dia_id);*/
            return horas.ToList();
        }
        public List<CargaHorariaDocente> Listar()
        {
            modeloEscuela db = new modeloEscuela();
            var horas = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                            .Include(e => e.Ambiente)
                                            .Include(e => e.HoraEntrada)
                                            .Include(e => e.HoraSalida)
                                            .Include(e => e.CargaDocenteCicloCurso.Curso)
                                            .Include(e => e.CargaDocenteCicloCurso.Docente);
            /*.GroupBy(e => e.dia_id);*/
            return horas.ToList();
        }

        // Metodo Obtener
        public CargaHorariaDocente obtener(int id)
        {
            var objCargaHorariaDocente = new CargaHorariaDocente();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objCargaHorariaDocente = db.CargaHorariaDocente.Include(e => e.CargaDocenteCicloCurso)
                                            .Include(e => e.Ambiente)
                                            .Include(e => e.HoraEntrada)
                                            .Include(e => e.HoraSalida)
                                            .Include(e => e.CargaDocenteCicloCurso.Curso)
                                            .Include(e => e.CargaDocenteCicloCurso.Docente)
                                            .Include(e => e.Dia)
                                            .Include(e => e.CargaDocenteCicloCurso.Ciclo)
                                            .Where(x => x.cargaDo_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCargaHorariaDocente;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.cargaDo_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }

        public void GuardarCurso()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.cargaDo_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch
            {
            }
        }

        //Metodo Eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
