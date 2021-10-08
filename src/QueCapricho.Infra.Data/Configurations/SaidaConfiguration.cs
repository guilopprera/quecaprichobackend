using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class SaidaConfiguration : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.HasKey(c => c.SaidaId);
            builder.Property(c => c.SaidaId).ValueGeneratedOnAdd();
            builder.Property(c => c.EncomendaId).IsRequired();
            builder.Property(c => c.DataSaida).IsRequired();
            builder.Property(c => c.Observacao).IsRequired();
            builder.Property(c => c.Apagado).IsRequired();
        }
    }
}
