using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class ProdutoFotoConfiguration : IEntityTypeConfiguration<ProdutoFoto>
    {
        public void Configure(EntityTypeBuilder<ProdutoFoto> builder)
        {
            builder.HasNoKey();
            builder.Property(c => c.FotoId).IsRequired();
            builder.Property(c => c.ProdutoId).IsRequired();
            builder.Property(c => c.ProdutoId).IsRequired();
        }
    }
}
