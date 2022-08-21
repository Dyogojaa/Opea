﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotalControl.DAL;

#nullable disable

namespace TotalControl.DAL.Migrations
{
    [DbContext(typeof(BDContexto))]
    partial class BDContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Cartao", b =>
                {
                    b.Property<int>("CartaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartaoId"), 1L, 1);

                    b.Property<string>("Bandeira")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Limite")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CartaoId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("Numero")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cartoes", (string)null);
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("Icone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.HasIndex("TipoId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Despesa", b =>
                {
                    b.Property<int>("DespesaId")
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CartaoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("DespesaId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MesId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Despesas", (string)null);
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Funcao", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcoes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "449862ea-1589-425d-94db-b983444aa4eb",
                            ConcurrencyStamp = "9acb24a2-f537-44df-be21-ed55f5e54fa8",
                            Descricao = "Administrador do Sistema",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "003c8859-f86d-469d-83f3-7cc284dfb4d9",
                            ConcurrencyStamp = "f5221ce9-a2c7-4057-95b8-35cf638fa06b",
                            Descricao = "Usuario do Sistema",
                            Name = "Usuario",
                            NormalizedName = "USUARIO"
                        });
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Ganho", b =>
                {
                    b.Property<int>("GanhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GanhoId"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GanhoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("MesId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ganhos", (string)null);
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Mes", b =>
                {
                    b.Property<int>("MesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("MesId");

                    b.HasIndex("MesId")
                        .IsUnique();

                    b.ToTable("Meses", (string)null);

                    b.HasData(
                        new
                        {
                            MesId = 1,
                            Nome = "Janeiro"
                        },
                        new
                        {
                            MesId = 2,
                            Nome = "Fevereiro"
                        },
                        new
                        {
                            MesId = 3,
                            Nome = "Março"
                        },
                        new
                        {
                            MesId = 4,
                            Nome = "Abril"
                        },
                        new
                        {
                            MesId = 5,
                            Nome = "Maio"
                        },
                        new
                        {
                            MesId = 6,
                            Nome = "Maio"
                        },
                        new
                        {
                            MesId = 7,
                            Nome = "Julho"
                        },
                        new
                        {
                            MesId = 8,
                            Nome = "Agosto"
                        },
                        new
                        {
                            MesId = 9,
                            Nome = "Setembro"
                        },
                        new
                        {
                            MesId = 10,
                            Nome = "Outubro"
                        },
                        new
                        {
                            MesId = 11,
                            Nome = "Novembro"
                        },
                        new
                        {
                            MesId = 12,
                            Nome = "Dezembro"
                        });
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Tipo", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoId"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("TipoId");

                    b.ToTable("Tipos", (string)null);

                    b.HasData(
                        new
                        {
                            TipoId = 1,
                            Nome = "Despesas"
                        },
                        new
                        {
                            TipoId = 2,
                            Nome = "Ganho"
                        });
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Cartao", b =>
                {
                    b.HasOne("TotalControl.BLL.Models.Usuario", "Usuario")
                        .WithMany("Cartaos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Categoria", b =>
                {
                    b.HasOne("TotalControl.BLL.Models.Tipo", "Tipo")
                        .WithMany("Categorias")
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Despesa", b =>
                {
                    b.HasOne("TotalControl.BLL.Models.Categoria", "Categoria")
                        .WithMany("Despesas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalControl.BLL.Models.Cartao", "Cartao")
                        .WithMany("Despesas")
                        .HasForeignKey("DespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalControl.BLL.Models.Mes", "Mes")
                        .WithMany("Despesas")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalControl.BLL.Models.Usuario", "Usuario")
                        .WithMany("Despesas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cartao");

                    b.Navigation("Categoria");

                    b.Navigation("Mes");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Ganho", b =>
                {
                    b.HasOne("TotalControl.BLL.Models.Categoria", "Categoria")
                        .WithMany("Ganhos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalControl.BLL.Models.Mes", "Mes")
                        .WithMany("Ganhos")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TotalControl.BLL.Models.Usuario", "Usuario")
                        .WithMany("Ganhos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Mes");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Cartao", b =>
                {
                    b.Navigation("Despesas");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Categoria", b =>
                {
                    b.Navigation("Despesas");

                    b.Navigation("Ganhos");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Mes", b =>
                {
                    b.Navigation("Despesas");

                    b.Navigation("Ganhos");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Tipo", b =>
                {
                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("TotalControl.BLL.Models.Usuario", b =>
                {
                    b.Navigation("Cartaos");

                    b.Navigation("Despesas");

                    b.Navigation("Ganhos");
                });
#pragma warning restore 612, 618
        }
    }
}
