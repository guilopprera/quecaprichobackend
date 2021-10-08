using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class EncomendaConfiguration : IEntityTypeConfiguration<Encomenda>
    {
        public void Configure(EntityTypeBuilder<Encomenda> builder)
        {
            builder.HasKey(c => c.EncomendaId);
            builder.Property(c => c.EncomendaId).ValueGeneratedOnAdd();
            builder.Property(c => c.ClienteId).IsRequired();
            builder.Property(a => a.DataEncomenda).IsRequired();
            builder.Property(c => c.DataEntrega).IsRequired();
            builder.Property(c => c.Valor).IsRequired().HasPrecision(10, 2);
            builder.Property(c => c.Ativo).IsRequired();
            builder.Property(c => c.Cancelado).IsRequired();
            builder.Property(c => c.Apagado).IsRequired();
        }
    }
}
