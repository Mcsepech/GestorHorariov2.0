namespace GestorHorariov2._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using System.Web;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int persona_id { get; set; }

        [Required]
        [StringLength(250)]
        public string usuario_nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string usuario_contraseña { get; set; }

        [StringLength(1)]
        public string usuario_estado { get; set; }

        public virtual Persona Persona { get; set; }


        public List<Usuario> Listar()
        {
            var objUsuario = new List<Usuario>();
            try
            {
                using (var db = new modeloEscuela())
                {
                    objUsuario = db.Usuario.Include("Persona").ToList();
                }
            }
            catch (Exception ex)
            { throw; }

            return objUsuario;
        }

        // Metodo Obtener
        public Usuario obtener(int id)
        {
            var objUsuario = new Usuario();

            try
            {
                using (var db = new modeloEscuela())
                {
                    objUsuario = db.Usuario.Where(x => x.usuario_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objUsuario;
        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new modeloEscuela())
                {
                    if (this.usuario_id > 0)
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

        /*--------------------- VALIDAR --------------------*/

        public ResponseModel ValidarLogin(string Usuario, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new modeloEscuela())
                {
                    Password = HashHelper.SHA1(Password);

                    var usuario = db.Usuario.Where(x => x.usuario_nombre == Usuario)
                                            .Where(x => x.usuario_contraseña == Password)
                                            .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.usuario_id.ToString());
                        rm.SetResponse(true, "Bievenido");
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuario o Password incorrectos...");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rm;
        }


        public ResponseModel GuardarPerfil(HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new modeloEscuela())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    var Usu = db.Entry(this);
                    Usu.State = EntityState.Modified;
                    
                    if (this.usuario_id == 0) Usu.Property(x => x.usuario_id).IsModified = false;
                    if (this.persona_id == 0) Usu.Property(x => x.persona_id).IsModified = false;
                    if (this.usuario_nombre == null) Usu.Property(x => x.usuario_nombre).IsModified = false;
                    if (this.usuario_contraseña == null) Usu.Property(x => x.usuario_contraseña).IsModified = false;
                    if (this.usuario_estado == null) Usu.Property(x => x.usuario_estado).IsModified = false;

                    db.SaveChanges();
                    rm.SetResponse(true);
                }

            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }


    }
}
