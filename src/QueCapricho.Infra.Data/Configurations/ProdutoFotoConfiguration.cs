using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class ProdutoFotoConfiguration : IEntityTypeConfiguration<ProdutoFoto>
    {
        public void Configure(EntityTypeBuilder<ProdutoFoto> builder)
        {
            builder.HasKey(p=> p.ProdutoFotoId);
            builder.Property(p=> p.ProdutoFotoId).ValueGeneratedOnAdd();
            builder.Property(c => c.ProdutoId).IsRequired();
            builder.Property(c => c.NomeFoto).HasColumnType("varchar(100)");
        }
    }
}
