using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.UsuarioId);
            builder.Property(c => c.UsuarioId).ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CPF).HasColumnType("char(14)").HasMaxLength(14).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Senha).HasMaxLength(100).IsRequired();

            //builder.HasData(new Usuario { UsuarioId = 12213214, Nome = "Renata", Email = "re-natalopes@hotmail.com", Senha = "91853057", CPF = "6600074884", Apagado = false });
        }
    }
}
