using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotalControl.API.ViewModel;
using TotalControl.BLL.Models;
using TotalControl.DAL.Interface;

namespace TotalControl.API.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncoesController : ControllerBase
    {
        private readonly IFuncaoRepositorio _repositorio;

        public FuncoesController(IFuncaoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcao>>> GetFuncoes()
        {

            return await _repositorio.PegarTodos().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcao>> GetFuncao(string id)
        {
            var funcao = await _repositorio.PegarPeloId(id);

            if (funcao == null)
            {
                return NotFound();
            }

            return funcao;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncao(string id, FuncoesViewModel funcoes)
        {
            if (id != funcoes.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {
                    Id = funcoes.Id,
                    Name = funcoes.Name,    
                    Descricao = funcoes.Descricao
                };

                await _repositorio.AtualizarFuncao(funcao);
                return Ok(new
                {
                    mensagem = $"Função {funcao.Descricao} atualizada com sucesso"

                });

            }
            return BadRequest(ModelState);

        }

        [HttpPost]
        public async Task<ActionResult<Funcao>> PostFuncao([FromBody] FuncoesViewModel funcoes)
        {

            if (ModelState.IsValid)
            {
                Funcao funcao = new Funcao
                {                    
                    Name = funcoes.Name,
                    Descricao = funcoes.Descricao
                };

                await _repositorio.AdicionarFuncao(funcao);
                return Ok(new
                {
                    mensagem = $"Função {funcao.Descricao} cadastrada com sucesso"

                });
            }
            return BadRequest(ModelState);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncao(string id)
        {
            var funcao = await _repositorio.PegarPeloId(id);

            if (funcao == null)
            {
                return NotFound();
            }

            await _repositorio.Excluir(funcao);

            return Ok(new
            {
                mensagem = $"Função {funcao.Descricao} excluida com sucesso"

            });
        }

        [HttpGet("FiltrarFuncoes/{nome}")]
        public async Task<ActionResult<IEnumerable<Funcao>>> FiltrarFuncoes(string nome)
        {
            return await _repositorio.FiltrarFuncoes(nome).ToListAsync();
        }
    }
}
