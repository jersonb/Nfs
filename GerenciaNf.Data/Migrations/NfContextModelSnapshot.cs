// <auto-generated />
using System;
using GerenciaNf.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciaNf.Data.Migrations
{
    [DbContext(typeof(NfContext))]
    partial class NfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("nf")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GerenciaNf.Data.Model.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TB_EMPRESA", "nf");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.Imposto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Aliquota")
                        .HasPrecision(2, 2)
                        .HasColumnType("decimal(2,2)");

                    b.Property<decimal>("BaseCalculo")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("TB_IMPOSTO", "nf");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ImpostoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ImpostoId");

                    b.ToTable("TB_ITEM", "nf");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.NotaFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DestinatarioId")
                        .HasColumnType("int");

                    b.Property<int>("EmissorId")
                        .HasColumnType("int");

                    b.Property<int>("ImpostoId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DestinatarioId");

                    b.HasIndex("EmissorId");

                    b.HasIndex("ImpostoId");

                    b.ToTable("TB_NOTA_FISCAL", "nf");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.NotaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("NotaId")
                        .HasColumnType("int");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("NotaId");

                    b.ToTable("TB_NOTA_ITEM", "nf");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.Item", b =>
                {
                    b.HasOne("GerenciaNf.Data.Model.Imposto", "Imposto")
                        .WithMany()
                        .HasForeignKey("ImpostoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imposto");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.NotaFiscal", b =>
                {
                    b.HasOne("GerenciaNf.Data.Model.Empresa", "Destinatario")
                        .WithMany("NotasDestinatario")
                        .HasForeignKey("DestinatarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GerenciaNf.Data.Model.Empresa", "Emissor")
                        .WithMany("NotasEmissor")
                        .HasForeignKey("EmissorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GerenciaNf.Data.Model.Imposto", "Imposto")
                        .WithMany()
                        .HasForeignKey("ImpostoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatario");

                    b.Navigation("Emissor");

                    b.Navigation("Imposto");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.NotaItem", b =>
                {
                    b.HasOne("GerenciaNf.Data.Model.Item", "Item")
                        .WithMany("NotasItens")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GerenciaNf.Data.Model.NotaFiscal", "Nota")
                        .WithMany("NotasItens")
                        .HasForeignKey("NotaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Nota");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.Empresa", b =>
                {
                    b.Navigation("NotasDestinatario");

                    b.Navigation("NotasEmissor");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.Item", b =>
                {
                    b.Navigation("NotasItens");
                });

            modelBuilder.Entity("GerenciaNf.Data.Model.NotaFiscal", b =>
                {
                    b.Navigation("NotasItens");
                });
#pragma warning restore 612, 618
        }
    }
}
