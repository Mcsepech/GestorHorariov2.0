namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class PlanEstudios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanEstudios()
        {
            Curso = new HashSet<Curso>();
        }

        [Key]
        public int plan_id { get; set; }

        [Required]
        [StringLength(250)]
        public string plan_nombre { get; set; }

        public int? plan_anio { get; set; }

        [StringLength(1)]
        public string plan_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Curso> Curso { get; set; }

        public List<PlanEstudios> Listar()
        {
            var objPlanEstudios = new List<PlanEstudios>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objPlanEstudios = db.PlanEstudios.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objPlanEstudios;
        }

        // Metodo Obtener
        public PlanEstudios obtener(int id)
        {
            var objPlanEstudios = new PlanEstudios();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objPlanEstudios = db.PlanEstudios.Where(x => x.plan_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objPlanEstudios;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.plan_id > 0)
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
