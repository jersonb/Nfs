#nullable disable

using GerenciaNf.Data.Contracts;
using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciaNf.Data
{
    public class NfContext : DbContext, INfContext
    {
        public NfContext(DbContextOptions<NfContext> options)
            : base(options)
        {
        }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Imposto> Impostos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<NotaItem> NotasItens { get; set; }

        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("nf");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NfContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}