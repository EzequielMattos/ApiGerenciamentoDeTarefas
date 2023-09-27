namespace GerenciamentoDeTarefas.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public IList<Tarefa> Tarefas { get; set; }
    }
}
