using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ClienteId);
            builder.Property(c => c.ClienteId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Email).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CPF).IsUnicode(false).IsUnicode(false).HasMaxLength(14).IsRequired();
        }
    }
}
