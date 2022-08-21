using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TotalControl.API.ViewModel;
using TotalControl.BLL.Models;
using TotalControl.DAL.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TotalControl.API.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio ?? throw new ArgumentNullException(nameof(usuarioRepositorio));
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string id)
        {
            var usuario = await _usuarioRepositorio.PegarPeloId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }


        [HttpPost("SalvarFoto")]
        public async Task<ActionResult> SalvarFoto()
        {
            var foto = Request.Form.Files[0];
            byte[] b;

            using (var openReadStream = foto.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    await openReadStream.CopyToAsync(memoryStream);
                    b = memoryStream.ToArray();
                }
            }

            return Ok(new
            {
                foto = b
            });
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<ActionResult> RegistrarUsuario(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult usuarioCriado;
                string funcaoUsuario;
                Usuario usuario = new Usuario
                {
                    UserName= model.NomeUsuario,
                    Email= model.Email, 
                    PasswordHash = model.Senha,
                    CPF=model.CPF,  
                    Profissao=model.Profissao,
                    Foto=model.Foto
                };

                if (await _usuarioRepositorio.PegarQtdUsuariosRegistrados()>0)
                {
                    funcaoUsuario = "Usuario";
                }
                else
                {
                    funcaoUsuario = "Administrador";
                                     
                }
                                

                usuarioCriado = await _usuarioRepositorio.CriarUsuario(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, funcaoUsuario);
                    await _usuarioRepositorio.LogarUsuario(usuario, false);
                    return Ok(new
                    {
                        emailUsuarioLogado = usuario.Email,
                        usuarioId = usuario.Id

                    });

                }
            }
            return BadRequest();

        }

        [HttpPost("LogarUsuario")]
        public async Task<ActionResult> LogarUsuario(LoginViewModel model)
        {
            if (model == null)            
                return NotFound("Usuário e/ou Senha Inválidos!");

            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPorEmail(model.Email);

            if(usuario != null)
            {
                PasswordHasher<Usuario> passwordhasher = new PasswordHasher<Usuario>();
                if (passwordhasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Senha) != PasswordVerificationResult.Failed)
                {
                    await _usuarioRepositorio.LogarUsuario(usuario, false);
                    return Ok(new
                    {
                        emailUsuarioLogado = usuario.Email,
                        usuarioId = usuario.Id


                    });
                }
                return NotFound("Usuário e/ou Senha Inválidos!");

            }
            return NotFound("Usuário e/ou Senha Inválidos!");

        }        
    }
}
