﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiGasolineras.Models
{
    public partial class _dbContext : DbContext
    {
        public _dbContext()
        {
        }

        public _dbContext(DbContextOptions<_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Coch> Coches { get; set; }
        public virtual DbSet<ComunidadesAutonoma> ComunidadesAutonomas { get; set; }
        public virtual DbSet<ComunidadesAutonomasProvincia> ComunidadesAutonomasProvincias { get; set; }
        public virtual DbSet<ComunidadesAutonomasProvinciasMunicipio> ComunidadesAutonomasProvinciasMunicipios { get; set; }
        public virtual DbSet<EstacionesServicio> EstacionesServicios { get; set; }
        public virtual DbSet<TiposCombustible> TiposCombustibles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Coch>(entity =>
            {
                entity.HasKey(e => e.IdCoche)
                    .HasName("PK__Coches__D1F2AC5591F8CEFB");

                entity.Property(e => e.codref)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.fecha_alta).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fecha_modificacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.guid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.mimeType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.url)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoCombustibleNavigation)
                    .WithMany(p => p.Coches)
                    .HasForeignKey(d => d.IdTipoCombustible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Coches__IdTipoCo__5535A963");
            });

            modelBuilder.Entity<ComunidadesAutonoma>(entity =>
            {
                entity.HasKey(e => e.IDCCAA)
                    .HasName("PK__Comunida__91A9FC2943DC7C18");

                entity.Property(e => e.IDCCAA).ValueGeneratedNever();

                entity.Property(e => e.CCAA)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.fecha_alta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fecha_modificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ComunidadesAutonomasProvincia>(entity =>
            {
                entity.HasKey(e => e.IDPovincia)
                    .HasName("PK__Comunida__EBCDEA37AD2857FD");

                entity.Property(e => e.IDPovincia).ValueGeneratedNever();

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.fecha_alta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fecha_modificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IDCCAANavigation)
                    .WithMany(p => p.ComunidadesAutonomasProvincia)
                    .HasForeignKey(d => d.IDCCAA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComunidadesAutonomasProvincias_ComunidadesAutonomas");
            });

            modelBuilder.Entity<ComunidadesAutonomasProvinciasMunicipio>(entity =>
            {
                entity.HasKey(e => e.IDMunicipio);

                entity.Property(e => e.IDMunicipio).ValueGeneratedNever();

                entity.Property(e => e.Municipio)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.fecha_alta).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fecha_modificacion).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EstacionesServicio>(entity =>
            {
                entity.HasKey(e => e.IDEESS)
                    .HasName("PK__Estacion__2153F2D70A014171");

                entity.ToTable("EstacionesServicio");

                entity.Property(e => e.IDEESS).ValueGeneratedNever();

                entity.Property(e => e.Dirección)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Horario)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Localidad)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud_WGS84)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Margen)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Precio_Biodiesel).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Bioetanol).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gas_Natural_Comprimido).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gas_Natural_Licuado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gases_licuados_del_petróleo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasoleo_A).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasoleo_B).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasoleo_Premium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasolina_95_E10).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasolina_95_E5).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasolina_95_E5_Premium).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasolina_98_E10).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Gasolina_98_E5).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Precio_Hidrogeno).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Remisión)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rótulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo_Venta)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDCCAANavigation)
                    .WithMany(p => p.EstacionesServicios)
                    .HasForeignKey(d => d.IDCCAA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstacionesServicio_ComunidadesAutonomas");

                entity.HasOne(d => d.IDMunicipioNavigation)
                    .WithMany(p => p.EstacionesServicios)
                    .HasForeignKey(d => d.IDMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstacionesServicio_ComunidadesAutonomasProvinciasMunicipios");

                entity.HasOne(d => d.IDProvinciaNavigation)
                    .WithMany(p => p.EstacionesServicios)
                    .HasForeignKey(d => d.IDProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstacionesServicio_ComunidadesAutonomasProvincias");
            });

            modelBuilder.Entity<TiposCombustible>(entity =>
            {
                entity.HasKey(e => e.IdTipoCombustible)
                    .HasName("PK__TiposCom__CFB7A37E236400B8");

                entity.HasIndex(e => e.combustible, "UQ__TiposCom__523CFDC287037341")
                    .IsUnique();

                entity.HasIndex(e => e.codref, "UQ__TiposCom__5C8B7E2616DC0411")
                    .IsUnique();

                entity.Property(e => e.codref)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.combustible)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.fecha_alta).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.fecha_modificacion).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}