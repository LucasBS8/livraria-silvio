﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using livrariaDB.Models;

#nullable disable

namespace livrariaDB.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("livrariaDB.Models.Emprestimo", b =>
                {
                    b.Property<int>("emprestimoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("emprestimoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("emprestimoId"));

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cliente");

                    b.Property<string>("dataDevolucao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("dataDevolucao");

                    b.Property<string>("dataEmprestimo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("dataEmprestimo");

                    b.Property<int>("livroId")
                        .HasColumnType("int")
                        .HasColumnName("livroId");

                    b.HasKey("emprestimoId");

                    b.HasIndex("livroId");

                    b.ToTable("emprestimo");
                });

            modelBuilder.Entity("livrariaDB.Models.Livro", b =>
                {
                    b.Property<int>("livroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("livroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("livroId"));

                    b.Property<string>("genero")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("genero");

                    b.Property<int>("isbn")
                        .HasColumnType("int")
                        .HasColumnName("isbn");

                    b.Property<string>("livroAutor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("livroAutor");

                    b.Property<string>("livroPublicacao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("livroPublicacao");

                    b.Property<string>("livroTitulo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("livroTitulo");

                    b.Property<int>("quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.HasKey("livroId");

                    b.ToTable("livro");
                });

            modelBuilder.Entity("livrariaDB.Models.Emprestimo", b =>
                {
                    b.HasOne("livrariaDB.Models.Livro", "livroEmprestimo")
                        .WithMany()
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livroEmprestimo");
                });
#pragma warning restore 612, 618
        }
    }
}
