namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Dia")]
    public partial class Dia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dia()
        {
            CargaHorariaDocente = new HashSet<CargaHorariaDocente>();
        }

        [Key]
        public int dia_id { get; set; }

        [Required]
        [StringLength(30)]
        public string dia_nombre { get; set; }

        [StringLength(1)]
        public string dia_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaHorariaDocente> CargaHorariaDocente { get; set; }

        public List<Dia> Listar()
        {
            var objDia = new List<Dia>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objDia = db.Dia.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objDia;
        }

        // Metodo Obtener
        public Dia obtener(int id)
        {
            var objDia = new Dia();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objDia = db.Dia.Where(x => x.dia_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDia;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.dia_id > 0)
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
