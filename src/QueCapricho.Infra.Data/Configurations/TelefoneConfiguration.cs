using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(c => c.TelefoneId);
            builder.Property(c => c.TelefoneId).ValueGeneratedOnAdd();
            builder.Property(c => c.ClienteId).IsRequired();
            builder.Property(c => c.Numero).HasMaxLength(20).IsRequired();
        }
    }
}
