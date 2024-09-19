using CadastroCliente;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Configuração do modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir chave primária da entidade Cliente
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);

            // Outras configurações podem ser adicionadas aqui se necessário no futuro
        }
    }
}
