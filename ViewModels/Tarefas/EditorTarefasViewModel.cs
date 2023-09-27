using GerenciamentoDeTarefas.Models.Enums;
using GerenciamentoDeTarefas.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.ViewModels.Tarefas
{
    public class EditorTarefasViewModel
    {
        [Required(ErrorMessage = "O campo TITULO é obrigatório!")]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public EPrioridade Prioridade { get; set; }

        [Required(ErrorMessage = "O campo STATUS é obrigatório!")]
        public EStatus Status { get; set; }

        [Required(ErrorMessage = "O campo CATEGORIA é obrigatório!")]
        public int Categoria { get; set; }

        [Required(ErrorMessage = "O campo USUÁRIO é obrigatório!")]
        public int User { get; set; }
    }
}
