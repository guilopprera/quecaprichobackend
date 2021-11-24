using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Infra.Data.Configurations;

namespace QueCapricho.Infra.Data.Context
{
    public class MeuContexto : IdentityDbContext
    {
        public MeuContexto() { }
        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options) { }
        public DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<EncomendaProduto> EncomendaProdutos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoFoto> ProdutoFotos { get; set; }
        public DbSet<FluxoCaixa> FluxoCaixa{ get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuContexto).Assembly);
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EncomendaConfiguration());
            modelBuilder.ApplyConfiguration(new EncomendaProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
            modelBuilder.ApplyConfiguration(new EstoqueConfiguration());
            modelBuilder.ApplyConfiguration(new FotoConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoFotoConfiguration());
            modelBuilder.ApplyConfiguration(new FluxoCaixaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
