using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciaNf.Data.Mapping
{
    public class ImpostoMapping : IEntityTypeConfiguration<Imposto>
    {
        public void Configure(EntityTypeBuilder<Imposto> builder)
        {
            builder.ToTable("TB_IMPOSTO");

            builder.Property(x => x.BaseCalculo)
                .HasPrecision(10, 2).HasColumnType("decimal(10,2)");

            builder.Property(x => x.Aliquota)
                .HasPrecision(2, 2);

            builder.Property(x => x.Descricao)
                .HasMaxLength(200);
        }
    }
}