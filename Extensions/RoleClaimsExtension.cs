using GerenciamentoDeTarefas.Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace GerenciamentoDeTarefas.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Nome)
            };
            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
            return result;
        }
    }
}
