using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROYECTORADIX.Models;

public partial class Radix1Context : DbContext
{
    public Radix1Context()
    {
    }

    public Radix1Context(DbContextOptions<Radix1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Aprendiz> Aprendizs { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Competencium> Competencia { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Ficha> Fichas { get; set; }

    public virtual DbSet<Jornadum> Jornada { get; set; }

    public virtual DbSet<Modalidad> Modalidads { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Novedad> Novedads { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    public virtual DbSet<ProgramaCompetencium> ProgramaCompetencia { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Red> Reds { get; set; }

    public virtual DbSet<Resultadoaprendizaje> Resultadoaprendizajes { get; set; }

    public virtual DbSet<TipoContrato> TipoContratos { get; set; }

    public virtual DbSet<TipoFormacion> TipoFormacions { get; set; }

    public virtual DbSet<TipoNovedad> TipoNovedads { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Tipodocumento> Tipodocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BUCDFPCSEFSD042; DataBase=RADIX1; TrustServerCertificate=True; Trusted_Connection= True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aprendiz>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__aprendiz__5217C1FD5388A0B3");

            entity.ToTable("aprendiz");

            entity.Property(e => e.NumeroId)
                .ValueGeneratedNever()
                .HasColumnName("numero_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo1)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("correo1");
            entity.Property(e => e.Correo2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("correo2");
            entity.Property(e => e.Direccion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdFicha).HasColumnName("id_ficha");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdTipodocumento).HasColumnName("id_tipodocumento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Observacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("observacion");
            entity.Property(e => e.Rh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("rh");
            entity.Property(e => e.Telefono1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono1");
            entity.Property(e => e.Telefono2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono2");

            entity.HasOne(d => d.IdFichaNavigation).WithMany(p => p.Aprendizs)
                .HasForeignKey(d => d.IdFicha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aprendiz__id_fic__66603565");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Aprendizs)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aprendiz__id_mun__656C112C");

            entity.HasOne(d => d.IdTipodocumentoNavigation).WithMany(p => p.Aprendizs)
                .HasForeignKey(d => d.IdTipodocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aprendiz__id_tip__6754599E");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__area__40F9A207558A8680");

            entity.ToTable("area");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Competencium>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__competen__40F9A207EB5C0D2A");

            entity.ToTable("competencia");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Duracion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("duracion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdResultadoApren).HasColumnName("id_ResultadoApren");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdResultadoAprenNavigation).WithMany(p => p.Competencia)
                .HasForeignKey(d => d.IdResultadoApren)
                .HasConstraintName("FK__competenc__id_Re__07C12930");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__departam__3213E83F5B08BBCE");

            entity.ToTable("departamento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdPais).HasColumnName("id_pais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__departame__id_pa__5FB337D6");
        });

        modelBuilder.Entity<Ficha>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ficha__3213E83FBF33DBB3");

            entity.ToTable("ficha");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaFinallectiva)
                .HasColumnType("datetime")
                .HasColumnName("fecha_finallectiva");
            entity.Property(e => e.FechaFinalpractica)
                .HasColumnType("datetime")
                .HasColumnName("fecha_finalpractica");
            entity.Property(e => e.FechaIniciolectiva)
                .HasColumnType("datetime")
                .HasColumnName("fecha_iniciolectiva");
            entity.Property(e => e.FechaIniciopractica)
                .HasColumnType("datetime")
                .HasColumnName("fecha_iniciopractica");
            entity.Property(e => e.IdInstructorlider).HasColumnName("id_instructorlider");
            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.IdModalidad).HasColumnName("id_modalidad");
            entity.Property(e => e.IdPrograma).HasColumnName("id_programa");
            entity.Property(e => e.IdTipoFormacion).HasColumnName("id_tipoFormacion");

            entity.HasOne(d => d.IdJornadaNavigation).WithMany(p => p.Fichas)
                .HasForeignKey(d => d.IdJornada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ficha__id_jornad__4BAC3F29");

            entity.HasOne(d => d.IdModalidadNavigation).WithMany(p => p.Fichas)
                .HasForeignKey(d => d.IdModalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ficha__id_modali__4D94879B");

            entity.HasOne(d => d.IdProgramaNavigation).WithMany(p => p.Fichas)
                .HasForeignKey(d => d.IdPrograma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ficha__id_progra__4AB81AF0");

            entity.HasOne(d => d.IdTipoFormacionNavigation).WithMany(p => p.Fichas)
                .HasForeignKey(d => d.IdTipoFormacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ficha__id_tipoFo__4CA06362");
        });

        modelBuilder.Entity<Jornadum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__jornada__3213E83F1BD1F7F5");

            entity.ToTable("jornada");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__modalida__3213E83F646557A8");

            entity.ToTable("modalidad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__municipi__3213E83F12C43560");

            entity.ToTable("municipio");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("barrio");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__municipio__id_de__628FA481");
        });

        modelBuilder.Entity<Novedad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__novedad__3213E83F24043AEF");

            entity.ToTable("novedad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.IdAprendiz).HasColumnName("id_aprendiz");
            entity.Property(e => e.IdTipoNovedad).HasColumnName("id_TipoNovedad");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdAprendizNavigation).WithMany(p => p.Novedads)
                .HasForeignKey(d => d.IdAprendiz)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__novedad__id_apre__0E6E26BF");

            entity.HasOne(d => d.IdTipoNovedadNavigation).WithMany(p => p.Novedads)
                .HasForeignKey(d => d.IdTipoNovedad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__novedad__id_Tipo__10566F31");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Novedads)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__novedad__id_usua__0F624AF8");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__pais__3213E83F31B9BEFD");

            entity.ToTable("pais");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__programa__3213E83FA0F5D5F7");

            entity.ToTable("programa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Creditos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("creditos");
            entity.Property(e => e.DuracionLectiva)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("duracion_lectiva");
            entity.Property(e => e.DuracionProductiva)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("duracion_productiva");
            entity.Property(e => e.Duraciontotal)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("duraciontotal");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdRed).HasColumnName("id_red");
            entity.Property(e => e.IdTipodeformacion).HasColumnName("id_tipodeformacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.VersionPrograma)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("version_programa");

            entity.HasOne(d => d.IdRedNavigation).WithMany(p => p.Programas)
                .HasForeignKey(d => d.IdRed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__programa__id_red__47DBAE45");

            entity.HasOne(d => d.IdTipodeformacionNavigation).WithMany(p => p.Programas)
                .HasForeignKey(d => d.IdTipodeformacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__programa__id_tip__46E78A0C");
        });

        modelBuilder.Entity<ProgramaCompetencium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__programa__3213E83F85409703");

            entity.ToTable("programa_Competencia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCompetencia).HasColumnName("id_competencia");
            entity.Property(e => e.IdPrograma).HasColumnName("id_Programa");

            entity.HasOne(d => d.IdCompetenciaNavigation).WithMany(p => p.ProgramaCompetencia)
                .HasForeignKey(d => d.IdCompetencia)
                .HasConstraintName("FK__programa___id_co__0A9D95DB");

            entity.HasOne(d => d.IdProgramaNavigation).WithMany(p => p.ProgramaCompetencia)
                .HasForeignKey(d => d.IdPrograma)
                .HasConstraintName("FK__programa___id_Pr__0B91BA14");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__proyecto__40F9A207AFB5B963");

            entity.ToTable("proyecto");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdPrograma).HasColumnName("id_programa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProgramaNavigation).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.IdPrograma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__proyecto__id_pro__6FE99F9F");
        });

        modelBuilder.Entity<Red>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__red__40F9A20762B1CC59");

            entity.ToTable("red");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Reds)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__red__id_area__33D4B598");
        });

        modelBuilder.Entity<Resultadoaprendizaje>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__resultad__40F9A20779CCEB12");

            entity.ToTable("resultadoaprendizaje");

            entity.Property(e => e.Codigo)
                .ValueGeneratedNever()
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
        });

        modelBuilder.Entity<TipoContrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipoCont__3213E83FADA46032");

            entity.ToTable("tipoContrato");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoFormacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipoForm__3213E83F1AE8A54C");

            entity.ToTable("tipoFormacion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoNovedad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipoNove__3213E83F9F1B7B61");

            entity.ToTable("tipoNovedad");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipoUsua__3213E83F9C38BEDA");

            entity.ToTable("tipoUsuario");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Tipodocumento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tipodocu__3213E83FDCCAD860");

            entity.ToTable("tipodocumento");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NumeroId).HasName("PK__usuario__5217C1FDDE8D7D4F");

            entity.ToTable("usuario");

            entity.Property(e => e.NumeroId)
                .ValueGeneratedNever()
                .HasColumnName("numero_id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaFinContrato)
                .HasColumnType("datetime")
                .HasColumnName("fecha_finContrato");
            entity.Property(e => e.FechaInicioContrato)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicioContrato");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdTipoContrato).HasColumnName("id_tipoContrato");
            entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipoUsuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__id_area__6B24EA82");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__id_muni__6A30C649");

            entity.HasOne(d => d.IdTipoContratoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoContrato)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__id_tipo__6C190EBB");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__id_tipo__6D0D32F4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
