using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.ViewModels.Categorias
{
    public class EditorCategoriasViewModel
    {
        [Required(ErrorMessage = "Informe o titulo da categoria!")]
        public string Titulo { get; set; }
    }
}
