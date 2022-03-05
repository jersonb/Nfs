using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaNf.Data.Mapping
{
    public class ItemMapping : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("TB_ITEM");

            builder.Property(x => x.Descricao)
                .HasMaxLength(200);

            builder.Property(x => x.Valor)
                .HasPrecision(10, 2)
                .HasColumnType("decimal(10,2)");
        }
    }
}