using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class FotoConfiguration : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            builder.HasKey(c => c.FotoId);
            builder.Property(c => c.FotoId).ValueGeneratedOnAdd();
            builder.Property(c => c.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Apagado).IsRequired();
        }
    }
}
