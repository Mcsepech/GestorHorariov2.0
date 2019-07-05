namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            CargaDocenteCicloCurso = new HashSet<CargaDocenteCicloCurso>();
        }

        [Key]
        public int curso_id { get; set; }

        public int plan_id { get; set; }

        [Required]
        [StringLength(250)]
        public string curso_nombre { get; set; }

        [StringLength(1)]
        public string curso_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaDocenteCicloCurso> CargaDocenteCicloCurso { get; set; }

        public virtual PlanEstudios PlanEstudios { get; set; }

        public List<Curso> Listar()
        {
            var objCurso = new List<Curso>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objCurso = db.Curso.Include("PlanEstudios").ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objCurso;
        }

        // Metodo Obtener
        public Curso obtener(int id)
        {
            var objCurso = new Curso();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objCurso = db.Curso.Where(x => x.curso_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCurso;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.curso_id > 0)
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
