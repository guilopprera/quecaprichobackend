using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class FluxoCaixaConfiguration : IEntityTypeConfiguration<FluxoCaixa>
    {
        public void Configure(EntityTypeBuilder<FluxoCaixa> builder)
        {
            builder.HasKey(f => f.FluxoCaixaId);
            builder.Property(f => f.Tipo).IsRequired();
            builder.Property(f => f.Valor).IsRequired();
            builder.Property(f => f.Descricao).IsRequired();
            builder.Property(f => f.Apagado).IsRequired();
            builder.Property(f => f.Data).IsRequired();
        }
    }
}
