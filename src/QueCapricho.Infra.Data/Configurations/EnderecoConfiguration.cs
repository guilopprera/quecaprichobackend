using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class EnderecoConfiguration: IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.EnderecoId);
            builder.Property(c => c.EnderecoId).ValueGeneratedOnAdd();
            builder.Property(c => c.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Apagado).IsRequired();
        }
    }
}
