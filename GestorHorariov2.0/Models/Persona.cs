namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int persona_id { get; set; }

        [Required]
        [StringLength(250)]
        public string persona_nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string persona_apellido { get; set; }

        [Required]
        [StringLength(250)]
        public string persona_correo { get; set; }

        [Required]
        [StringLength(9)]
        public string persona_celular { get; set; }

        [StringLength(1)]
        public string persona_estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        public List<Persona> Listar()
        {
            var pbjPersona = new List<Persona>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    pbjPersona = db.Persona.ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return pbjPersona;
        }

        // Metodo Obtener
        public Persona obtener(int id)
        {
            var pbjPersona = new Persona();

            try
            {
                using (var db = new modeloEscuela())
                {
                    pbjPersona = db.Persona.Where(x => x.persona_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return pbjPersona;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.persona_id > 0)
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
