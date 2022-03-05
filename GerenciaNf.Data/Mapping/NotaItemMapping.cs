using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaNf.Data.Mapping
{
    public class NotaItemMapping : IEntityTypeConfiguration<NotaItem>
    {
        public void Configure(EntityTypeBuilder<NotaItem> builder)
        {
            builder.ToTable("TB_NOTA_ITEM");

            builder.HasOne(x => x.Nota)
                .WithMany(x => x.NotasItens)
                .HasForeignKey(x => x.NotaId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Item)
             .WithMany(x => x.NotasItens)
             .HasForeignKey(x => x.ItemId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}