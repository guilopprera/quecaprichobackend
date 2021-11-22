using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);
            builder.Property(p => p.ProdutoId).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Valor).IsRequired().HasPrecision(10, 2);
            builder.Property(p => p.Ativo).IsRequired();
            builder.Property(p => p.Apagado).IsRequired();
            builder.Ignore(p => p.ProdutoFotos);
        }
    }
}
