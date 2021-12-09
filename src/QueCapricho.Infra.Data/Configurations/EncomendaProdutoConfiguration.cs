using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class EncomendaProdutoConfiguration : IEntityTypeConfiguration<EncomendaProduto>
    {
        public void Configure(EntityTypeBuilder<EncomendaProduto> builder)
        {
            builder.HasKey(ep => ep.EncomendaProdutoId);
            builder.Property(ep => ep.EncomendaProdutoId).ValueGeneratedOnAdd();
            builder.Property(ep => ep.EncomendaId).IsRequired();
            builder.Property(ep => ep.ProdutoId).IsRequired();
        }
    }
}
