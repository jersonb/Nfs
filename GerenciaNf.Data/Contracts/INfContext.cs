using GerenciaNf.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GerenciaNf.Data.Contracts
{
    public interface INfContext
    {
        public DbSet<NotaFiscal> NotaFiscal { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Imposto> Impostos { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<NotaItem> NotasItens { get; set; }

        public Task SaveChangesAsync();
        public EntityEntry Entry(object entity);
    }
}