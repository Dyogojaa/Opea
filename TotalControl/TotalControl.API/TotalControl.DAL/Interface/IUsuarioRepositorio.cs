using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalControl.BLL.Models;
using TotalControl.DAL.Repositorios;

namespace TotalControl.DAL.Interface
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {

        Task<int> PegarQtdUsuariosRegistrados();

        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);

        Task IncluirUsuarioEmFuncao(Usuario usuario,string funcao);

        Task LogarUsuario(Usuario usuario, bool lembrar);

        Task<Usuario> PegarUsuarioPorEmail(string email);



    }
}
