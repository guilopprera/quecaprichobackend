using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class CategoriaProdutoConfiguration : IEntityTypeConfiguration<CategoriaProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            builder.HasKey(c => c.CategoriaProdutoId);
            builder.Property(c => c.CategoriaProdutoId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsUnicode(false).HasMaxLength(100).IsRequired();
        }
    }
}
