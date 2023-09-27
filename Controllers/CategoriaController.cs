using GerenciamentoDeTarefas.Data;
using GerenciamentoDeTarefas.Extensions;
using GerenciamentoDeTarefas.Models;
using GerenciamentoDeTarefas.ViewModels.Categorias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace GerenciamentoDeTarefas.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly TarefaDataContext _context;
        public CategoriaController(TarefaDataContext context)
        {
            _context = context;
        }

        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetAsync([FromQuery] int skip = 0, [FromQuery] int take = 20)
        {
            try
            {
                var count = await _context.Categorias.CountAsync();
                var categorias = await _context.Categorias.AsNoTracking().Skip(skip).Take(take).ToListAsync();
                return Ok(new
                {
                    count,
                    categorias
                });
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpGet("v1/categorias/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                return Ok(categoria);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpPost("v1/categorias")]
        public async Task<IActionResult> PostAync([FromBody] EditorCategoriasViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.GetErrors());

                var categoria = new Categoria()
                {
                    Titulo = model.Titulo
                };

                await _context.Categorias.AddAsync(categoria);
                await _context.SaveChangesAsync();

                return Ok(model);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpPut("v1/categorias/{id:int}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoriasViewModel model)
        {
            try
            {
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                categoria.Titulo = model.Titulo;

                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();

                return Ok(model);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }

        [HttpDelete("v1/categorias/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var categoria = await _context.Categorias.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

                if (categoria == null)
                    return StatusCode(400, "Nenhum registro foi encontrado!");

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return Ok(categoria);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor!");
            }
        }
    }
}
