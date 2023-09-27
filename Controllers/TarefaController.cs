using GerenciamentoDeTarefas.Data;
using GerenciamentoDeTarefas.Extensions;
using GerenciamentoDeTarefas.Models;
using GerenciamentoDeTarefas.ViewModels.Tarefas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeTarefas.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaDataContext _context;
        public TarefaController(TarefaDataContext context)
        {
            _context = context;
        }        

        [HttpGet("v1/tarefas/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

                if (tarefa == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                return Ok(tarefa);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [Authorize]
        [HttpPost("v1/tarefas")]
        public async Task<IActionResult> PostAsync([FromBody] EditorTarefasViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrors());

                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == model.Categoria);

                if (categoria == null)
                    return StatusCode(400, "Nenhuma categoria foi encontrado!");

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == model.User);

                if (user == null)
                    return StatusCode(400, "Nenhum usuário foi encontrado!");

                var tarefa = new Tarefa()
                {
                    Titulo = model.Titulo,
                    Descricao = model.Descricao,
                    DataVencimento = model.DataVencimento,
                    CreateDate = DateTime.UtcNow,
                    Prioridade = model.Prioridade,
                    Status = model.Status,
                    Categoria = categoria,
                    User = user
                };

                await _context.Tarefas.AddAsync(tarefa);
                await _context.SaveChangesAsync();

                return Ok(tarefa);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [Authorize]
        [HttpPut("v1/tarefas/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorTarefasViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrors());

                var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

                if (tarefa == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == model.Categoria);

                if (categoria == null)
                    return StatusCode(400, "Nenhuma categoria foi encontrado!");

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == model.User);

                if (user == null)
                    return StatusCode(400, "Nenhum usuário foi encontrado!");

                tarefa.Titulo = model.Titulo;
                tarefa.Descricao = model.Descricao;
                tarefa.DataVencimento = model.DataVencimento;
                tarefa.Prioridade = model.Prioridade;
                tarefa.Status = model.Status;
                tarefa.Categoria = categoria;
                tarefa.User = user;

                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();

                return Ok(tarefa);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [Authorize]
        [HttpDelete("v1/tarefas/{id:int}")]
        public async Task<IActionResult> DeteleAsync([FromRoute] int id)
        {
            try
            {
                var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

                if (tarefa == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                return Ok(tarefa);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }


        }
    }
}
