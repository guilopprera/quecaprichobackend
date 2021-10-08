using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.EnderecoId);
            builder.Property(c => c.EnderecoId).ValueGeneratedOnAdd();
            builder.Property(c => c.ClienteId).IsRequired();
            builder.Property(c => c.Logradouro).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Numero).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(100).IsRequired();
        }
    }
}
