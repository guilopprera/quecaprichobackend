using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(c => c.LogId);
            builder.Property(c => c.LogId).ValueGeneratedOnAdd();
            builder.Property(c => c.ValorAntigo).IsRequired().HasPrecision(10, 2);
            builder.Property(c => c.ValorNovo).IsRequired().HasPrecision(10, 2);
            builder.Property(c => c.DataLog).IsRequired();
            builder.Property(c => c.Evento).IsRequired();
        }
    }
}
