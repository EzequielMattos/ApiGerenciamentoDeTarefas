using GerenciamentoDeTarefas.Models;
using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.ViewModels.Users
{
    public class EditorUsersViewModel
    {
        [Required(ErrorMessage = "O campo NOME é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo NOME não pode contar mais do que 100 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo E-MAIL é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo E-MAIL não pode contar mais do que 100 caracteres!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo SENHA é obrigatório!")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "A SENHA deve conter entre 6 e 16 caracteres!")]
        public string Password { get; set; }
    }
}
