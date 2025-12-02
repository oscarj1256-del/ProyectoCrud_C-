using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OzzyWeb1.Models;

public partial class SabormasterclassContext : DbContext
{
    public SabormasterclassContext()
    {
    }

    public SabormasterclassContext(DbContextOptions<SabormasterclassContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acudiente> Acudientes { get; set; }

    public virtual DbSet<AdmiSisitema> AdmiSisitemas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<EstadoAdim> EstadoAdims { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<HistorialCurso> HistorialCursos { get; set; }

    public virtual DbSet<Inscripcion> Inscripcions { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Notificación> Notificacións { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tutor> Tutores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Acudiente>(entity =>
        {
            entity.HasKey(e => e.IdAcudiente).HasName("PRIMARY");

            entity.ToTable("acudiente");

            entity.HasIndex(e => e.PersonaIdPersona, "Persona_idPersona");

            entity.HasIndex(e => e.IdEstudienteDependiente, "fk_Id_Estudiente_dependiente");

            entity.Property(e => e.IdAcudiente)
                .HasColumnType("int(11)")
                .HasColumnName("idAcudiente");
            entity.Property(e => e.Autorizacion).HasMaxLength(45);
            entity.Property(e => e.IdEstudienteDependiente)
                .HasColumnType("int(11)")
                .HasColumnName("Id_Estudiente_dependiente");
            entity.Property(e => e.PersonaIdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("Persona_idPersona");

            entity.HasOne(d => d.IdEstudienteDependienteNavigation).WithMany(p => p.Acudientes)
                .HasForeignKey(d => d.IdEstudienteDependiente)
                .HasConstraintName("fk_Id_Estudiente_dependiente");

            entity.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.Acudientes)
                .HasForeignKey(d => d.PersonaIdPersona)
                .HasConstraintName("acudiente_ibfk_1");
        });

        modelBuilder.Entity<AdmiSisitema>(entity =>
        {
            entity.HasKey(e => e.IdAdmiSisitema).HasName("PRIMARY");

            entity.ToTable("admi_sisitema");

            entity.HasIndex(e => e.PersonaIdPersona, "Persona_idPersona");

            entity.HasIndex(e => e.IdEstadoAdministrador, "fk_id_estado_admin");

            entity.Property(e => e.IdAdmiSisitema)
                .HasColumnType("int(11)")
                .HasColumnName("idAdmi_Sisitema");
            entity.Property(e => e.CodigoAdmin)
                .HasMaxLength(45)
                .HasColumnName("Codigo_admin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.IdEstadoAdministrador)
                .HasColumnType("int(11)")
                .HasColumnName("id_estado_administrador");
            entity.Property(e => e.PersonaIdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("Persona_idPersona");
            entity.Property(e => e.UltimaConexión)
                .HasMaxLength(45)
                .HasColumnName("Ultima_Conexión");

            entity.HasOne(d => d.IdEstadoAdministradorNavigation).WithMany(p => p.AdmiSisitemas)
                .HasForeignKey(d => d.IdEstadoAdministrador)
                .HasConstraintName("fk_id_estado_admin");

            entity.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.AdmiSisitemas)
                .HasForeignKey(d => d.PersonaIdPersona)
                .HasConstraintName("admi_sisitema_ibfk_1");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.HasIndex(e => e.EstudianteIdEstudiante, "fk_id_Estudiante");

            entity.Property(e => e.IdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("idCategoria");
            entity.Property(e => e.EstudianteIdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_id_Estudiante");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.EstudianteIdEstudianteNavigation).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.EstudianteIdEstudiante)
                .HasConstraintName("fk_id_Estudiante");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PRIMARY");

            entity.ToTable("curso");

            entity.HasIndex(e => e.CategoriaIdCategoria, "Categoria_idCategoria");

            entity.Property(e => e.IdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("idCurso");
            entity.Property(e => e.CategoriaIdCategoria)
                .HasColumnType("int(11)")
                .HasColumnName("Categoria_idCategoria");
            entity.Property(e => e.Costo).HasPrecision(10, 2);
            entity.Property(e => e.Detalle).HasMaxLength(255);
            entity.Property(e => e.Duracion).HasMaxLength(150);
            entity.Property(e => e.NivelAprendizaje)
                .HasMaxLength(100)
                .HasColumnName("Nivel_Aprendizaje");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.NumeroCurso)
                .HasMaxLength(45)
                .HasColumnName("Numero_Curso");

            entity.HasOne(d => d.CategoriaIdCategoriaNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.CategoriaIdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("curso_ibfk_1");
        });

        modelBuilder.Entity<EstadoAdim>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estado_adim");

            entity.Property(e => e.IdEstado)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("Id_estado");
            entity.Property(e => e.Estado).HasMaxLength(45);
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PRIMARY");

            entity.ToTable("estudiante");

            entity.HasIndex(e => e.PersonaIdPersona, "Persona_idPersona");

            entity.HasIndex(e => e.IdEstadoEstudiante, "fk_id_estado_estudiante");

            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("idEstudiante");
            entity.Property(e => e.Contraseña).HasMaxLength(100);
            entity.Property(e => e.IdEstadoEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estado_estudiante");
            entity.Property(e => e.PersonaIdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("Persona_idPersona");
            entity.Property(e => e.Progreso).HasMaxLength(45);

            entity.HasOne(d => d.IdEstadoEstudianteNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.IdEstadoEstudiante)
                .HasConstraintName("fk_id_estado_estudiante");

            entity.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.Estudiantes)
                .HasForeignKey(d => d.PersonaIdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudiante_ibfk_1");
        });

        modelBuilder.Entity<HistorialCurso>(entity =>
        {
            entity.HasKey(e => e.IdHistorialCurso).HasName("PRIMARY");

            entity.ToTable("historial_curso");

            entity.HasIndex(e => e.CursoIdCurso, "Curso_idCurso");

            entity.HasIndex(e => e.EstudianteIdEstudiante, "Estudiante_idEstudiante");

            entity.Property(e => e.IdHistorialCurso)
                .HasColumnType("int(11)")
                .HasColumnName("idHistorial_Curso");
            entity.Property(e => e.CantidadCurso)
                .HasMaxLength(100)
                .HasColumnName("Cantidad_Curso");
            entity.Property(e => e.CursoIdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("Curso_idCurso");
            entity.Property(e => e.CursosTomados)
                .HasMaxLength(100)
                .HasColumnName("Cursos_Tomados");
            entity.Property(e => e.EstudianteIdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_idEstudiante");

            entity.HasOne(d => d.CursoIdCursoNavigation).WithMany(p => p.HistorialCursos)
                .HasForeignKey(d => d.CursoIdCurso)
                .HasConstraintName("historial_curso_ibfk_2");

            entity.HasOne(d => d.EstudianteIdEstudianteNavigation).WithMany(p => p.HistorialCursos)
                .HasForeignKey(d => d.EstudianteIdEstudiante)
                .HasConstraintName("historial_curso_ibfk_1");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PRIMARY");

            entity.ToTable("inscripcion");

            entity.HasIndex(e => e.EstudianteIdEstudiante, "Estudiante_idEstudiante");

            entity.HasIndex(e => e.IdEstadoInscripcion, "fk_id_estado_inscripcion");

            entity.Property(e => e.IdInscripcion)
                .HasColumnType("int(11)")
                .HasColumnName("idInscripcion");
            entity.Property(e => e.EstudianteIdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_idEstudiante");
            entity.Property(e => e.FechaInscripcion).HasColumnName("Fecha_Inscripcion");
            entity.Property(e => e.IdEstadoInscripcion)
                .HasColumnType("int(11)")
                .HasColumnName("Id_estado_inscripcion");

            entity.HasOne(d => d.EstudianteIdEstudianteNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.EstudianteIdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inscripcion_ibfk_1");

            entity.HasOne(d => d.IdEstadoInscripcionNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdEstadoInscripcion)
                .HasConstraintName("fk_id_estado_inscripcion");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PRIMARY");

            entity.ToTable("inventario");

            entity.Property(e => e.IdInventario)
                .HasColumnType("int(11)")
                .HasColumnName("idInventario");
            entity.Property(e => e.Cantidad).HasColumnType("int(11)");
            entity.Property(e => e.FechaRegistro).HasColumnName("Fecha_Registro");
            entity.Property(e => e.StockMaximo)
                .HasColumnType("int(11)")
                .HasColumnName("Stock_Maximo");
            entity.Property(e => e.StockMinimo)
                .HasColumnType("int(11)")
                .HasColumnName("Stock_Minimo");
            entity.Property(e => e.UltimaActualización)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("Ultima_Actualización");
        });

        modelBuilder.Entity<Notificación>(entity =>
        {
            entity.HasKey(e => e.IdNotificación).HasName("PRIMARY");

            entity.ToTable("notificación");

            entity.HasIndex(e => e.AdmiSisitemaIdAdmiSisitema, "Admi_Sisitema_idAdmi_Sisitema");

            entity.HasIndex(e => e.EstudianteIdEstudiante, "Estudiante_idEstudiante");

            entity.Property(e => e.IdNotificación)
                .HasColumnType("int(11)")
                .HasColumnName("idNotificación");
            entity.Property(e => e.AdmiSisitemaIdAdmiSisitema)
                .HasColumnType("int(11)")
                .HasColumnName("Admi_Sisitema_idAdmi_Sisitema");
            entity.Property(e => e.CodigoNotificacion)
                .HasMaxLength(45)
                .HasColumnName("Codigo_Notificacion");
            entity.Property(e => e.EstudianteIdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_idEstudiante");
            entity.Property(e => e.FechaEnvio)
                .HasMaxLength(45)
                .HasColumnName("Fecha_Envio");
            entity.Property(e => e.Mensaje).HasMaxLength(45);
            entity.Property(e => e.Tipo).HasMaxLength(45);

            entity.HasOne(d => d.AdmiSisitemaIdAdmiSisitemaNavigation).WithMany(p => p.Notificacións)
                .HasForeignKey(d => d.AdmiSisitemaIdAdmiSisitema)
                .HasConstraintName("notificación_ibfk_1");

            entity.HasOne(d => d.EstudianteIdEstudianteNavigation).WithMany(p => p.Notificacións)
                .HasForeignKey(d => d.EstudianteIdEstudiante)
                .HasConstraintName("notificación_ibfk_2");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("pago");

            entity.HasIndex(e => e.EstudianteIdEstudiante, "Estudiante_idEstudiante");

            entity.Property(e => e.IdPago)
                .HasColumnType("int(11)")
                .HasColumnName("idPago");
            entity.Property(e => e.Estado).HasMaxLength(45);
            entity.Property(e => e.EstudianteIdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("Estudiante_idEstudiante");
            entity.Property(e => e.FechaPago).HasColumnName("Fecha_Pago");
            entity.Property(e => e.Metodo).HasMaxLength(45);
            entity.Property(e => e.Monto).HasPrecision(10, 2);

            entity.HasOne(d => d.EstudianteIdEstudianteNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.EstudianteIdEstudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_ibfk_1");

            entity.HasMany(d => d.CursoIdCursos).WithMany(p => p.PagoIdPagos)
                .UsingEntity<Dictionary<string, object>>(
                    "PagoHasCurso",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoIdCurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pago_has_curso_ibfk_2"),
                    l => l.HasOne<Pago>().WithMany()
                        .HasForeignKey("PagoIdPago")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("pago_has_curso_ibfk_1"),
                    j =>
                    {
                        j.HasKey("PagoIdPago", "CursoIdCurso")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("pago_has_curso");
                        j.HasIndex(new[] { "CursoIdCurso" }, "Curso_idCurso");
                        j.IndexerProperty<int>("PagoIdPago")
                            .HasColumnType("int(11)")
                            .HasColumnName("Pago_idPago");
                        j.IndexerProperty<int>("CursoIdCurso")
                            .HasColumnType("int(11)")
                            .HasColumnName("Curso_idCurso");
                    });
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.HasIndex(e => e.IdRol, "fk_persona_rol");

            entity.Property(e => e.IdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("id_persona");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.DireccionPersona)
                .HasMaxLength(255)
                .HasColumnName("Direccion_Persona");
            entity.Property(e => e.EmailPersona)
                .HasMaxLength(255)
                .HasColumnName("email_persona");
            entity.Property(e => e.Genero)
                .HasMaxLength(255)
                .HasColumnName("genero");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");
            entity.Property(e => e.NoDocumento)
                .HasMaxLength(255)
                .HasColumnName("no_documento");
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(255)
                .HasColumnName("nombre_persona");
            entity.Property(e => e.TelefonoPersona)
                .HasMaxLength(255)
                .HasColumnName("telefono_persona");
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(255)
                .HasColumnName("tipo_documento");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_persona_rol");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.CodProducto, "Cod_Producto").IsUnique();

            entity.HasIndex(e => e.InventarioIdInventario, "Inventario_idInventario");

            entity.Property(e => e.IdProducto)
                .HasColumnType("int(11)")
                .HasColumnName("idProducto");
            entity.Property(e => e.CodProducto)
                .HasMaxLength(100)
                .HasColumnName("Cod_Producto");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.InventarioIdInventario)
                .HasColumnType("int(11)")
                .HasColumnName("Inventario_idInventario");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Valor).HasPrecision(10, 2);

            entity.HasOne(d => d.InventarioIdInventarioNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.InventarioIdInventario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("producto_ibfk_1");

            entity.HasMany(d => d.ProveedorIdProveedors).WithMany(p => p.ProductoIdProductos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductoHasProveedor",
                    r => r.HasOne<Proveedor>().WithMany()
                        .HasForeignKey("ProveedorIdProveedor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("producto_has_proveedor_ibfk_2"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductoIdProducto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("producto_has_proveedor_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ProductoIdProducto", "ProveedorIdProveedor")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("producto_has_proveedor");
                        j.HasIndex(new[] { "ProveedorIdProveedor" }, "Proveedor_idProveedor");
                        j.IndexerProperty<int>("ProductoIdProducto")
                            .HasColumnType("int(11)")
                            .HasColumnName("Producto_idProducto");
                        j.IndexerProperty<int>("ProveedorIdProveedor")
                            .HasColumnType("int(11)")
                            .HasColumnName("Proveedor_idProveedor");
                    });
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.HasIndex(e => e.PersonaIdPersona, "fk_id_persona");

            entity.Property(e => e.IdProveedor)
                .HasColumnType("int(11)")
                .HasColumnName("idProveedor");
            entity.Property(e => e.NoProveedor)
                .HasMaxLength(45)
                .HasColumnName("No_Proveedor");
            entity.Property(e => e.PersonaIdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("Persona_id_Persona");
            entity.Property(e => e.Ubicacion).HasMaxLength(255);

            entity.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.PersonaIdPersona)
                .HasConstraintName("fk_id_persona");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.DescripcionRol)
                .HasMaxLength(20)
                .HasColumnName("descripcionRol");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.IdTutor).HasName("PRIMARY");

            entity.ToTable("tutor");

            entity.HasIndex(e => e.PersonaIdPersona, "Persona_idPersona");

            entity.Property(e => e.IdTutor)
                .HasColumnType("int(11)")
                .HasColumnName("idTutor");
            entity.Property(e => e.Experiencia).HasMaxLength(100);
            entity.Property(e => e.Observaciones).HasMaxLength(200);
            entity.Property(e => e.PersonaIdPersona)
                .HasColumnType("int(11)")
                .HasColumnName("Persona_idPersona");

            entity.HasOne(d => d.PersonaIdPersonaNavigation).WithMany(p => p.Tutores)
                .HasForeignKey(d => d.PersonaIdPersona)
                .HasConstraintName("tutor_ibfk_1");

            entity.HasMany(d => d.CursoIdCursos).WithMany(p => p.TutorIdTutores)
                .UsingEntity<Dictionary<string, object>>(
                    "TutorHasCurso",
                    r => r.HasOne<Curso>().WithMany()
                        .HasForeignKey("CursoIdCurso")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tutor_has_curso_ibfk_2"),
                    l => l.HasOne<Tutor>().WithMany()
                        .HasForeignKey("TutorIdTutor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("tutor_has_curso_ibfk_1"),
                    j =>
                    {
                        j.HasKey("TutorIdTutor", "CursoIdCurso")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("tutor_has_curso");
                        j.HasIndex(new[] { "CursoIdCurso" }, "Curso_idCurso");
                        j.IndexerProperty<int>("TutorIdTutor")
                            .HasColumnType("int(11)")
                            .HasColumnName("Tutor_idTutor");
                        j.IndexerProperty<int>("CursoIdCurso")
                            .HasColumnType("int(11)")
                            .HasColumnName("Curso_idCurso");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
