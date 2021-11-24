using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(t => t.TelefoneId);
            builder.Property(t => t.TelefoneId).ValueGeneratedOnAdd();
            builder.Property(t => t.Numero).HasMaxLength(15).IsRequired();
            builder.Property(t => t.Apagado).IsRequired();
        }
    }
}
