using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotalControl.BLL.Models;
using TotalControl.DAL;
using TotalControl.DAL.Interface;

namespace TotalControl.API.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepositorio _repositorio;

        public CategoriasController(ICategoriaRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }
                
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            
            return await _repositorio.PegarTodos().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {   
            var categoria = await _repositorio.PegarPeloId(id); 

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _repositorio.Atualizar(categoria);
                return Ok(new
                {
                    mensagem =$"Categoria {categoria.Nome} atualizada com sucesso"

                });

            }
            return BadRequest(ModelState);
            
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria([FromBody] Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                await _repositorio.Inserir(categoria);
                return Ok(new
                {
                    mensagem = $"Categoria {categoria.Nome} cadastrada com sucesso"

                });
            }
            return BadRequest(categoria);

        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _repositorio.PegarPeloId(id); 

            if (categoria == null)
            {
                return NotFound();
            }

            await _repositorio.Excluir(id);

            return Ok(new
            {
                mensagem = $"Categoria {categoria.Nome} excluida com sucesso"

            });
        }

        [HttpGet("FiltrarCategorias/{nome}")]
        public async Task<ActionResult<IEnumerable<Categoria>>> FiltrarCategorias(string nome)
        {
            return await _repositorio.FiltrarCategoria(nome).ToListAsync();
        }
    }
}
