using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class EncomendaProdutoConfiguration : IEntityTypeConfiguration<EncomendaProduto>
    {
        public void Configure(EntityTypeBuilder<EncomendaProduto> builder)
        {
            builder.HasKey(c => c.EncomendaId);
            builder.Property(c => c.EncomendaId).ValueGeneratedOnAdd();
            builder.Property(c => c.EncomendaId).IsRequired();
            builder.Property(c => c.ProdutoId).IsRequired();
        }
    }
}
