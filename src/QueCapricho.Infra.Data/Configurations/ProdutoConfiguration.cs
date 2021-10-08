using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.ProdutoId);
            builder.Property(c => c.ProdutoId).ValueGeneratedOnAdd();
            builder.Property(c => c.CategoriaProdutoId).IsRequired();
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Valor).IsRequired().HasPrecision(10, 2);
            builder.Property(c => c.Ativo).IsRequired();
            builder.Property(c => c.Apagado).IsRequired();
            builder.Ignore(p => p.ProdutoFotos);
        }
    }
}
