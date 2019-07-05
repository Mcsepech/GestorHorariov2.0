namespace GestorHorariov2._0.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class modeloEscuela : DbContext
    {
        public modeloEscuela()
            : base("name=modeloEscuela")
        {
        }

        public virtual DbSet<Ambiente> Ambiente { get; set; }
        public virtual DbSet<CargaDocenteCicloCurso> CargaDocenteCicloCurso { get; set; }
        public virtual DbSet<CargaHorariaDocente> CargaHorariaDocente { get; set; }
        public virtual DbSet<Ciclo> Ciclo { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<HoraEntrada> HoraEntrada { get; set; }
        public virtual DbSet<HoraSalida> HoraSalida { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PlanEstudios> PlanEstudios { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ambiente>()
                .Property(e => e.ambiente_codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Ambiente>()
                .Property(e => e.ambiente_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ambiente>()
                .Property(e => e.ambiente_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ambiente>()
                .HasMany(e => e.CargaHorariaDocente)
                .WithRequired(e => e.Ambiente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CargaDocenteCicloCurso>()
                .Property(e => e.carga_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CargaDocenteCicloCurso>()
                .HasMany(e => e.CargaHorariaDocente)
                .WithRequired(e => e.CargaDocenteCicloCurso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CargaHorariaDocente>()
                .Property(e => e.carga_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .Property(e => e.ciclo_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .Property(e => e.ciclo_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .HasMany(e => e.CargaDocenteCicloCurso)
                .WithRequired(e => e.Ciclo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.curso_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.curso_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.CargaDocenteCicloCurso)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dia>()
                .Property(e => e.dia_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Dia>()
                .Property(e => e.dia_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Dia>()
                .HasMany(e => e.CargaHorariaDocente)
                .WithRequired(e => e.Dia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.docente_codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.docente_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.docente_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.docente_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.CargaDocenteCicloCurso)
                .WithRequired(e => e.Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoraEntrada>()
                .Property(e => e.entrada_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoraEntrada>()
                .HasMany(e => e.CargaHorariaDocente)
                .WithRequired(e => e.HoraEntrada)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoraSalida>()
                .Property(e => e.salida_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoraSalida>()
                .HasMany(e => e.CargaHorariaDocente)
                .WithRequired(e => e.HoraSalida)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.persona_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.persona_apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.persona_correo)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.persona_celular)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.persona_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Persona)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanEstudios>()
                .Property(e => e.plan_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PlanEstudios>()
                .Property(e => e.plan_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PlanEstudios>()
                .HasMany(e => e.Curso)
                .WithRequired(e => e.PlanEstudios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semestre>()
                .Property(e => e.semestre_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Semestre>()
                .Property(e => e.semestre_estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Semestre>()
                .HasMany(e => e.CargaDocenteCicloCurso)
                .WithRequired(e => e.Semestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario_contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario_estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
