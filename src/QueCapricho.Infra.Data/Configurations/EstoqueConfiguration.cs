using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class EstoqueConfiguration : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(c => c.EstoqueId);
            builder.Property(c => c.EstoqueId).ValueGeneratedOnAdd();
            builder.Property(c => c.ProdutoId).IsRequired();
            builder.Property(c => c.Quantidade).IsRequired();
        }
    }
}
