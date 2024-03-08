﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using activos.Models;

#nullable disable

namespace activos.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("activos.Models.ActivoFijo", b =>
                {
                    b.Property<int>("Id_activo_fijo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("DepreciacionAcumulada")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id_departamento")
                        .HasColumnType("int");

                    b.Property<int>("Id_tipo_activo")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCompra")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id_activo_fijo");

                    b.HasIndex("Id_departamento");

                    b.HasIndex("Id_tipo_activo");

                    b.ToTable("ActivosFijos");
                });

            modelBuilder.Entity("activos.Models.Departamento", b =>
                {
                    b.Property<int>("Id_departamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id_departamento");

                    b.ToTable("departamentos");
                });

            modelBuilder.Entity("activos.Models.Empleado", b =>
                {
                    b.Property<int>("Id_empleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Id_departamento")
                        .HasColumnType("int");

                    b.Property<int>("Id_tipo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id_empleado");

                    b.HasIndex("Id_departamento");

                    b.HasIndex("Id_tipo");

                    b.ToTable("empleado");
                });

            modelBuilder.Entity("activos.Models.Tipo", b =>
                {
                    b.Property<int>("Id_tipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Tipo_persona")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id_tipo");

                    b.ToTable("tipo");
                });

            modelBuilder.Entity("activos.Models.TipoActivo", b =>
                {
                    b.Property<int>("Id_tipo_activo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CuentaContableCompra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CuentaContableDepreciacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Estado")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id_tipo_activo");

                    b.ToTable("TipoActivos");
                });

            modelBuilder.Entity("activos.Models.ActivoFijo", b =>
                {
                    b.HasOne("activos.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("Id_departamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("activos.Models.TipoActivo", "TipoActivo")
                        .WithMany("ActivosFijos")
                        .HasForeignKey("Id_tipo_activo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("TipoActivo");
                });

            modelBuilder.Entity("activos.Models.Empleado", b =>
                {
                    b.HasOne("activos.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("Id_departamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("activos.Models.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("Id_tipo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("activos.Models.TipoActivo", b =>
                {
                    b.Navigation("ActivosFijos");
                });
#pragma warning restore 612, 618
        }
    }
}
