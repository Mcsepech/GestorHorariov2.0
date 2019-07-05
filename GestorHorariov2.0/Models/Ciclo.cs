namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Ciclo")]
    public partial class Ciclo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ciclo()
        {
            CargaDocenteCicloCurso = new HashSet<CargaDocenteCicloCurso>();
        }

        [Key]
        public int ciclo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string ciclo_nombre { get; set; }

        [StringLength(1)]
        public string ciclo_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaDocenteCicloCurso> CargaDocenteCicloCurso { get; set; }

        public List<Ciclo> Listar()
        {
            var objCiclo = new List<Ciclo>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objCiclo = db.Ciclo.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objCiclo;
        }

        // Metodo Obtener
        public Ciclo obtener(int id)
        {
            var objCiclo = new Ciclo();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objCiclo = db.Ciclo.Where(x => x.ciclo_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCiclo;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.ciclo_id > 0)
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
