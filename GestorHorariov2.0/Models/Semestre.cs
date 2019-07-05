namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Semestre")]
    public partial class Semestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semestre()
        {
            CargaDocenteCicloCurso = new HashSet<CargaDocenteCicloCurso>();
        }

        [Key]
        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string semestre_nombre { get; set; }

        [StringLength(1)]
        public string semestre_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaDocenteCicloCurso> CargaDocenteCicloCurso { get; set; }


        public List<Semestre> Listar()
        {
            var objSemestre = new List<Semestre>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objSemestre = db.Semestre.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objSemestre;
        }

        // Metodo Obtener
        public Semestre obtener(int id)
        {
            var objSemestre = new Semestre();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objSemestre = db.Semestre.Where(x => x.semestre_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objSemestre;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.semestre_id > 0)
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
