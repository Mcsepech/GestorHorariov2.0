namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HoraEntrada")]
    public partial class HoraEntrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoraEntrada()
        {
            CargaHorariaDocente = new HashSet<CargaHorariaDocente>();
        }

        [Key]
        public int entrada_id { get; set; }

        public TimeSpan entrada_hora { get; set; }

        [StringLength(1)]
        public string entrada_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaHorariaDocente> CargaHorariaDocente { get; set; }


        public List<HoraEntrada> Listar()
        {
            var objHoraEntrada = new List<HoraEntrada>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objHoraEntrada = db.HoraEntrada.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objHoraEntrada;
        }

        // Metodo Obtener
        public HoraEntrada obtener(int id)
        {
            var objHoraEntrada = new HoraEntrada();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objHoraEntrada = db.HoraEntrada.Where(x => x.entrada_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objHoraEntrada;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.entrada_id > 0)
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
