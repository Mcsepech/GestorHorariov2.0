namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HoraSalida")]
    public partial class HoraSalida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoraSalida()
        {
            CargaHorariaDocente = new HashSet<CargaHorariaDocente>();
        }

        [Key]
        public int salida_id { get; set; }

        public TimeSpan salida_hora { get; set; }

        [StringLength(1)]
        public string salida_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaHorariaDocente> CargaHorariaDocente { get; set; }

        public List<HoraSalida> Listar()
        {
            var objHoraSalida = new List<HoraSalida>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objHoraSalida = db.HoraSalida.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objHoraSalida;
        }

        // Metodo Obtener
        public HoraSalida obtener(int id)
        {
            var objHoraSalida = new HoraSalida();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objHoraSalida = db.HoraSalida.Where(x => x.salida_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objHoraSalida;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.salida_id > 0)
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
