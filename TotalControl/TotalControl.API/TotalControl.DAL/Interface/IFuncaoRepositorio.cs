using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalControl.BLL.Models;
using TotalControl.DAL.Repositorios;

namespace TotalControl.DAL.Interface
{
    public interface IFuncaoRepositorio: IRepositorioGenerico<Funcao>
    {
        Task AdicionarFuncao(Funcao funcao);
        Task AtualizarFuncao(Funcao funcao);

        IQueryable<Funcao> FiltrarFuncoes(string nome);
    }
}
