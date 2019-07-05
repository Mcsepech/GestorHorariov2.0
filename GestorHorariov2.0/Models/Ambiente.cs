namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Ambiente")]
    public partial class Ambiente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ambiente()
        {
            CargaHorariaDocente = new HashSet<CargaHorariaDocente>();
        }

        [Key]
        public int ambiente_id { get; set; }

        [Required]
        [StringLength(30)]
        public string ambiente_codigo { get; set; }

        [Required]
        [StringLength(30)]
        public string ambiente_nombre { get; set; }

        [StringLength(1)]
        public string ambiente_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaHorariaDocente> CargaHorariaDocente { get; set; }

        public List<Ambiente> Listar()
        {
            var objAmbiente = new List<Ambiente>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objAmbiente = db.Ambiente.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objAmbiente;
        }

        // Metodo Obtener
        public Ambiente obtener(int id)
        {
            var objAmbiente = new Ambiente();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objAmbiente = db.Ambiente.Where(x => x.ambiente_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objAmbiente;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.ambiente_id > 0)
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
