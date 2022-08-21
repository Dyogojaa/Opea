using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TotalControl.BLL.Models;
using TotalControl.DAL;
using TotalControl.DAL.Interface;

namespace TotalControl.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly ITipoRepositorio _repositorio;

        public TiposController(ITipoRepositorio repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTipos()
        {   
            return await _repositorio.PegarTodos().ToListAsync();
        }
        
    }
}
