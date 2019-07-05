namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("CargaDocenteCicloCurso")]
    public partial class CargaDocenteCicloCurso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CargaDocenteCicloCurso()
        {
            CargaHorariaDocente = new HashSet<CargaHorariaDocente>();
        }

        [Key]
        public int carga_id { get; set; }

        public int semestre_id { get; set; }

        public int ciclo_id { get; set; }

        public int curso_id { get; set; }

        public int docente_id { get; set; }

        public int hora_ocu { get; set; }

        public int hora_lib { get; set; }

        [StringLength(1)]
        public string carga_estado { get; set; }

        public virtual Ciclo Ciclo { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Docente Docente { get; set; }

        public virtual Semestre Semestre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaHorariaDocente> CargaHorariaDocente { get; set; }


        public CargaDocenteCicloCurso obtenerDocente(int id)
        {
            modeloEscuela db = new modeloEscuela();
            CargaDocenteCicloCurso objDoc = db.CargaDocenteCicloCurso.Find(id);
            return objDoc;
        }
        public List<CargaDocenteCicloCurso> Listar()
        {
            modeloEscuela db = new modeloEscuela();
            var carga = db.CargaDocenteCicloCurso.Include(e => e.Docente).Include(e => e.Ciclo).Include(e => e.Curso);
            return carga.ToList();
        }

        public List<CargaDocenteCicloCurso> obtenerCursoCiclo(string ciclo)
        {
            modeloEscuela db = new modeloEscuela();
            var carga = db.CargaDocenteCicloCurso.Include(e => e.Docente)
                .Include(e => e.Ciclo)
                .Include(e => e.Curso)
                .Include(e => e.Semestre)
                .Where(e => e.Ciclo.ciclo_nombre == ciclo)
                .Where(e => e.hora_lib != 0);
            return carga.ToList();
        }

        public List<CargaDocenteCicloCurso> obtenerSemestre(string semestre)
        {
            modeloEscuela db = new modeloEscuela();
            var carga = db.CargaDocenteCicloCurso.Include(e => e.Docente)
                .Include(e => e.Ciclo)
                .Include(e => e.Curso)
                .Include(e => e.Semestre)
                .Where(e => e.Semestre.semestre_nombre == semestre);
            return carga.ToList();
        }

        public CargaDocenteCicloCurso listarHoras(int idCarga)
        {
            modeloEscuela db = new modeloEscuela();
            var carga = db.CargaDocenteCicloCurso.Where(e => e.carga_id == idCarga).SingleOrDefault();
            return carga;
        }

        // Metodo Obtener

        public List<CargaDocenteCicloCurso> obtener(int id)
        {
            modeloEscuela db = new modeloEscuela();
            var objCargaDocenteCicloCurso = db.CargaDocenteCicloCurso.Include(e => e.Docente)
                                                                    .Include(e => e.Ciclo)
                                                                    .Include(e => e.Curso)
                                                                    .Include(e => e.Semestre)
                                                                    .Where(x => x.ciclo_id == id);
            return objCargaDocenteCicloCurso.ToList();
        }

        /*obtener el nombre del ciclo*/
        public List<CargaDocenteCicloCurso> obtener2(string id)
        {
            modeloEscuela db = new modeloEscuela();
            var objCargaDocenteCicloCurso = db.CargaDocenteCicloCurso.Include(e => e.Docente)
                                                                    .Include(e => e.Ciclo)
                                                                    .Include(e => e.Curso)
                                                                    .Include(e => e.Semestre)
                                                                    .Where(x => x.Ciclo.ciclo_nombre == id);
            return objCargaDocenteCicloCurso.ToList();
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.carga_id > 0)
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
