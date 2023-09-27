namespace GerenciamentoDeTarefas.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<Role> Roles { get; set; } = new List<Role>();
        public List<Tarefa> Tarefas { get; set; } = new ();
    }
}
