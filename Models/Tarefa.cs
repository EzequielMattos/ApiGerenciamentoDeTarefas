using GerenciamentoDeTarefas.Models.Enums;

namespace GerenciamentoDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime CreateDate { get; set; }
        public EPrioridade Prioridade { get; set; }
        public EStatus Status { get; set; }
        public Categoria Categoria { get; set; }
        public User User { get; set; }
    }
}
