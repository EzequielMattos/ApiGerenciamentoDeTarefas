using GerenciamentoDeTarefas.Data.Mappings;
using GerenciamentoDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeTarefas.Data
{
    public class TarefaDataContext : DbContext
    {
        public TarefaDataContext(DbContextOptions<TarefaDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CategoriasMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
