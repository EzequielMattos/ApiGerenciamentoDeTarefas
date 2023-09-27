using GerenciamentoDeTarefas.Data;
using GerenciamentoDeTarefas.Extensions;
using GerenciamentoDeTarefas.Models;
using GerenciamentoDeTarefas.Services;
using GerenciamentoDeTarefas.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;
using System.Text.RegularExpressions;

namespace GerenciamentoDeTarefas.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TarefaDataContext _context;
        private readonly TokenService _token;

        public UserController(TarefaDataContext context, TokenService token)
        {
            _context = context;
            _token = token;
        }

        [HttpGet("v1/users")]
        public async Task<IActionResult> GetAsync([FromQuery]int skip = 0, [FromQuery]int take = 20)
        {
            try
            {
                var count = await _context.Users.CountAsync();
                var users = await _context.Users.AsNoTracking().Skip(skip).Take(take).ToListAsync();
                return Ok(new
                {
                    count,
                    users
                });
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpGet("v1/users/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpPost("v1/users")]
        public async Task<IActionResult> PostAsync([FromBody] EditorUsersViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrors());

                var user = new User
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Password = PasswordHasher.Hash(model.Password),
                    CreateDate = DateTime.UtcNow,
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    nome = user.Nome, 
                    email = model.Email, 
                    password = model.Password
                });
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpPut("v1/user/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorUsersViewModel model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                user.Nome = model.Nome;
                user.Email = model.Email;
                user.Password = PasswordHasher.Hash(model.Password);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpDelete("v1/users/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpPost("v1/users/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState.GetErrors());

            var user = await _context.Users.AsNoTracking().Include(u => u.Roles).FirstOrDefaultAsync();

            if (user == null)
                return StatusCode(400, "E-mail ou senha inválidos!");

            if (!PasswordHasher.Verify(user.Password, model.Password))
                return StatusCode(400, "E-mail ou senha inválidos!");

            try
            {
                var token = _token.GenerateToken(user);
                return Ok(token);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [Authorize]
        [HttpGet("v1/users/tarefas/{userId:int}")]
        public async Task<IActionResult> GetAllByUserAsync([FromRoute] int userId, [FromQuery] int skip, [FromQuery] int take)
        {
            try
            {
                var count = await _context.Tarefas.CountAsync();
                var tarefas = await _context.Tarefas.AsNoTracking().Where(t => t.User.Id == userId).Skip(skip).Take(take).ToListAsync();

                return Ok(new
                {
                    count,
                    tarefas
                });
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }
    }
}
