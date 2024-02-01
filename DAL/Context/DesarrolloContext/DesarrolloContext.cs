using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using env;
using Microsoft.Extensions.Logging;


namespace DAL.Context.DesarrolloContext;

public partial class DesarrolloContext : DbContext
{
    public DesarrolloContext()
    {
    }

    public DesarrolloContext(DbContextOptions<DesarrolloContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DOCUMENTOS_LOTE> DOCUMENTOS_LOTEs { get; set; }

    public virtual DbSet<ESTADO_LOTE> ESTADO_LOTEs { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empleado_tiendum> Empleado_tienda { get; set; }

    public virtual DbSet<PERFILE> PERFILEs { get; set; }

    public virtual DbSet<RECIBOS_CARGADO> RECIBOS_CARGADOs { get; set; }

    public virtual DbSet<TIENDA> TIENDAs { get; set; }

    public virtual DbSet<USUARIOS_SIST> USUARIOS_SISTs { get; set; }

    public virtual DbSet<usuario_perfil> usuario_perfils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(IConfigurationService.getConectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DOCUMENTOS_LOTE>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__DOCUMENT__3213E83FF02708D6");

            entity.ToTable("DOCUMENTOS_LOTES");
        });

        modelBuilder.Entity<ESTADO_LOTE>(entity =>
        {
            entity.HasKey(e => e.ID_ESTADO).HasName("PK__ESTADO_L__241E2E01DF630B8C");

            entity.ToTable("ESTADO_LOTE");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.id_Empleado).HasName("PK__Empleado__F119CCB3BDA05B7F");

            entity.Property(e => e.BANCO).HasMaxLength(100);
            entity.Property(e => e.CALLE).HasMaxLength(100);
            entity.Property(e => e.CUIT).HasMaxLength(100);
            entity.Property(e => e.FECHA_ALTA).HasMaxLength(100);
            entity.Property(e => e.FECHA_BAJA).HasMaxLength(100);
            entity.Property(e => e.LOCALIDAD).HasMaxLength(100);
            entity.Property(e => e.MAIL).HasMaxLength(100);
            entity.Property(e => e.NRO_CUENTA).HasMaxLength(100);
            entity.Property(e => e.TALLE_CHOMBA).HasMaxLength(25);
            entity.Property(e => e.TALLE_PANTALON).HasMaxLength(25);
            entity.Property(e => e.TURNO).HasMaxLength(50);
            entity.Property(e => e.UNIFORME).HasMaxLength(200);
            entity.Property(e => e.VTO_FECHA_SANITARIA).HasMaxLength(100);
            entity.Property(e => e.apellido).HasMaxLength(50);
            entity.Property(e => e.fecha_nac).HasMaxLength(50);
            entity.Property(e => e.nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Empleado_tiendum>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.id_emp_tienda).ValueGeneratedOnAdd();

            entity.HasOne(d => d.ID_TIENDANavigation).WithMany()
                .HasForeignKey(d => d.ID_TIENDA)
                .HasConstraintName("FK__Empleado___ID_TI__4D94879B");

            entity.HasOne(d => d.id_EmpleadoNavigation).WithMany()
                .HasForeignKey(d => d.id_Empleado)
                .HasConstraintName("FK__Empleado___id_Em__4CA06362");
        });

        modelBuilder.Entity<PERFILE>(entity =>
        {
            entity.HasKey(e => e.ID_PERFIL).HasName("PK__PERFILES__90BDE80935D10FCD");

            entity.ToTable("PERFILES");

            entity.Property(e => e.NOMBRE_PERFIL).HasMaxLength(100);
        });

        modelBuilder.Entity<RECIBOS_CARGADO>(entity =>
        {
            entity.HasKey(e => e.ID_RECIBO).HasName("PK__RECIBOS___07C4F05248FB70FA");

            entity.ToTable("RECIBOS_CARGADOS");

            entity.Property(e => e.CUIT).HasMaxLength(11);
        });

        modelBuilder.Entity<TIENDA>(entity =>
        {
            entity.HasKey(e => e.ID_TIENDA).HasName("PK__TIENDAS__E47F760357EA5FBD");

            entity.ToTable("TIENDAS");

            entity.Property(e => e.LOCALIDAD).HasMaxLength(100);
        });

        modelBuilder.Entity<USUARIOS_SIST>(entity =>
        {
            entity.HasKey(e => e.ID_USUARIO).HasName("PK__USUARIOS__91136B90E61DF199");

            entity.ToTable("USUARIOS_SIST");
        });

        modelBuilder.Entity<usuario_perfil>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usuario_perfil");

            entity.Property(e => e.id_usuario_perfil).ValueGeneratedOnAdd();

            entity.HasOne(d => d.ID_PERFILNavigation).WithMany()
                .HasForeignKey(d => d.ID_PERFIL)
                .HasConstraintName("FK__usuario_p__ID_PE__4F7CD00D");

            entity.HasOne(d => d.ID_USUARIONavigation).WithMany()
                .HasForeignKey(d => d.ID_USUARIO)
                .HasConstraintName("FK__usuario_p__ID_US__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
