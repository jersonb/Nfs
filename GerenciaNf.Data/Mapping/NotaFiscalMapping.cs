using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaNf.Data.Mapping
{
    public class NotaFiscalMapping : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.ToTable("TB_NOTA_FISCAL");

            builder.Property(x => x.Numero)
                .HasMaxLength(20);

            builder.HasOne(x => x.Destinatario)
                .WithMany(x => x.NotasDestinatario)
                .HasForeignKey(x => x.DestinatarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Emissor)
             .WithMany(x => x.NotasEmissor)
             .HasForeignKey(x => x.EmissorId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Imposto);
        }
    }
}