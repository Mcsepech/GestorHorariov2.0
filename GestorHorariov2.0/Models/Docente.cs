namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Docente")]
    public partial class Docente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Docente()
        {
            CargaDocenteCicloCurso = new HashSet<CargaDocenteCicloCurso>();
        }

        [Key]
        public int docente_id { get; set; }

        [Required]
        [StringLength(30)]
        public string docente_codigo { get; set; }

        [Required]
        [StringLength(30)]
        public string docente_nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string docente_apellido { get; set; }

        [StringLength(1)]
        public string docente_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CargaDocenteCicloCurso> CargaDocenteCicloCurso { get; set; }

        public List<Docente> Listar()
        {
            var objDocente = new List<Docente>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objDocente = db.Docente.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objDocente;
        }

        // Metodo Obtener
        public Docente obtener(int id)
        {
            var objDocente = new Docente();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objDocente = db.Docente.Where(x => x.docente_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objDocente;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.docente_id > 0)
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
