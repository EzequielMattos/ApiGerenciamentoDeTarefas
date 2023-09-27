using System.ComponentModel.DataAnnotations;

namespace GerenciamentoDeTarefas.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail para prosseguir!")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha para prosseguir!")]
        public string Password { get; set; }
    }
}
