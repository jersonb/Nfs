using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaNf.Data.Mapping
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("TB_EMPRESA");

            builder.Property(x => x.Nome)
                .HasMaxLength(200);

            builder.Property(x => x.Cnpj)
                .HasMaxLength(14);

            builder.HasMany<NotaFiscal>(x => x.NotasDestinatario)
                .WithOne(x => x.Destinatario)
                .HasForeignKey(x => x.DestinatarioId);

            builder.HasMany<NotaFiscal>(x => x.NotasEmissor)
               .WithOne(x => x.Emissor)
               .HasForeignKey(x => x.EmissorId);
        }
    }
}