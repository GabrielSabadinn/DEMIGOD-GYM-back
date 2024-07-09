using Microsoft.EntityFrameworkCore;
using MinhaApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.InMemory;
namespace MinhaApi.Data
{
    public class MinhaApiContext : DbContext
    {
        public MinhaApiContext(DbContextOptions<MinhaApiContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Instrutor> Instrutores { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<AvaliacaoFisica> AvaliacoesFisicas { get; set; }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Conta> Contas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<Instrutor>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<Plano>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<Modalidade>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<AvaliacaoFisica>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<Maquina>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<Filial>(C => { C.HasKey(X => new { X.Id }); });
            modelBuilder.Entity<Conta>(C => { C.HasKey(X => new { X.Id }); });
        }
    }
}
