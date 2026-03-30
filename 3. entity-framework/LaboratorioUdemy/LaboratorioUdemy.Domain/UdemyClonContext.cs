using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioUdemy.Domain;

public partial class UdemyClonContext : DbContext
{
    public UdemyClonContext()
    {
    }

    public UdemyClonContext(DbContextOptions<UdemyClonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Instructore> Instructores { get; set; }

    public virtual DbSet<Leccione> Lecciones { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Resena> Resenas { get; set; }

    public virtual DbSet<Seccione> Secciones { get; set; }

    public virtual DbSet<TipoLeccion> TipoLeccions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;User=sa;Password=Admin1234@;Database=UdemyClon;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__F353C1E5357EA0D6");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.CategoriaPadre).WithMany(p => p.InverseCategoriaPadre)
                .HasForeignKey(d => d.CategoriaPadreId)
                .HasConstraintName("FK_Categoria_Padre");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E0235D72EB126C4");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Idioma).HasMaxLength(50);
            entity.Property(e => e.Nivel).HasMaxLength(50);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Titulo).HasMaxLength(250);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cursos_Categoria");

            entity.HasMany(d => d.Estudiantes).WithMany(p => p.Cursos)
                .UsingEntity<Dictionary<string, object>>(
                    "ListaDeseo",
                    r => r.HasOne<Estudiante>().WithMany()
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Wish_Estudiante"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Wish_Curso"),
                    j =>
                    {
                        j.HasKey("CursoId", "EstudianteId").HasName("PK__ListaDes__E8F55DFA195C4B3F");
                        j.ToTable("ListaDeseos");
                    });

            entity.HasMany(d => d.Instructors).WithMany(p => p.Cursos)
                .UsingEntity<Dictionary<string, object>>(
                    "CursoInstructor",
                    r => r.HasOne<Instructore>().WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CI_Instructor"),
                    l => l.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CI_Curso"),
                    j =>
                    {
                        j.HasKey("CursoId", "InstructorId").HasName("PK__CursoIns__D7D2257E51105540");
                        j.ToTable("CursoInstructor");
                    });
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PK__Estudian__6F7682D8F8F29C6F");

            entity.HasIndex(e => e.Email, "UQ__Estudian__A9D10534A6A6FD34").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.InscripcionId).HasName("PK__Inscripc__168316B9FC5B7524");

            entity.HasIndex(e => new { e.EstudianteId, e.CursoId }, "UC_Estudiante_Curso").IsUnique();

            entity.Property(e => e.CuponCodigo).HasMaxLength(20);
            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.PrecioPagado).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscrip_Curso");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscrip_Estudiante");
        });

        modelBuilder.Entity<Instructore>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010A9B6F1569FE");

            entity.HasIndex(e => e.Email, "UQ__Instruct__A9D10534B1471D75").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Leccione>(entity =>
        {
            entity.HasKey(e => e.LeccionId).HasName("PK__Leccione__5C59E7C38A057896");

            entity.Property(e => e.Titulo).HasMaxLength(255);

            entity.HasOne(d => d.Seccion).WithMany(p => p.Lecciones)
                .HasForeignKey(d => d.SeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lecciones_Seccion");

            entity.HasOne(d => d.TipoLeccion).WithMany(p => p.Lecciones)
                .HasForeignKey(d => d.TipoLeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lecciones_Tipo");
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => new { e.EstudianteId, e.LeccionId }).HasName("PK__Progreso__4AB31CA4443CAECC");

            entity.ToTable("Progreso");

            entity.Property(e => e.FechaTerminada).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prog_Estudiante");

            entity.HasOne(d => d.Leccion).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.LeccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prog_Leccion");
        });

        modelBuilder.Entity<Resena>(entity =>
        {
            entity.HasKey(e => new { e.EstudianteId, e.CursoId }).HasName("PK__Resenas__0896A185E7B1B405");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Resena1)
                .HasMaxLength(250)
                .HasColumnName("Resena");

            entity.HasOne(d => d.Curso).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resena_Curso");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Resenas)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resena_Estudiante");
        });

        modelBuilder.Entity<Seccione>(entity =>
        {
            entity.HasKey(e => e.SeccionId).HasName("PK__Seccione__18B61641DADCDA75");

            entity.Property(e => e.Titulo).HasMaxLength(255);

            entity.HasOne(d => d.Curso).WithMany(p => p.Secciones)
                .HasForeignKey(d => d.CursoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Secciones_Curso");
        });

        modelBuilder.Entity<TipoLeccion>(entity =>
        {
            entity.HasKey(e => e.TipoLeccionId).HasName("PK__TipoLecc__B0CC52E49FFBC53F");

            entity.ToTable("TipoLeccion");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
