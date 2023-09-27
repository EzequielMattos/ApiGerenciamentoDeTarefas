using GerenciamentoDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoDeTarefas.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Titulo).IsRequired().HasColumnName("Titulo").HasColumnType("VARCHAR").HasMaxLength(100);
            builder.Property(x => x.Descricao).HasColumnName("Descricao").HasColumnType("VARCHAR").HasMaxLength(255);
            builder.Property(x => x.DataVencimento).HasColumnName("DataVencimento").HasColumnType("DATETIME");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("DATETIME").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).IsRequired().HasColumnName("Status").HasColumnType("VARCHAR").HasMaxLength(50);
            builder.HasOne(x => x.Categoria).WithMany(x => x.Tarefas).HasConstraintName("FK_Tarefa_Categoria").OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithMany(x => x.Tarefas).HasConstraintName("FK_Tarefa_User").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
