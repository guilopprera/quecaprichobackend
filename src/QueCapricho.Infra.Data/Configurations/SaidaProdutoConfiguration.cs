using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class SaidaProdutoConfiguration : IEntityTypeConfiguration<SaidaProduto>
    {
        public void Configure(EntityTypeBuilder<SaidaProduto> builder)
        {
            builder.HasKey(c => c.SaidaProdutoId);
            builder.Property(c => c.SaidaProdutoId).ValueGeneratedOnAdd();
            builder.Property(c => c.ProdutoId).IsRequired();
            builder.Property(c => c.SaidaId).IsRequired();
        }
    }
}
