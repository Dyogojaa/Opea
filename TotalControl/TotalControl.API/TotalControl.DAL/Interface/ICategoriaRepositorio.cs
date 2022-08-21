using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalControl.BLL.Models;
using TotalControl.DAL.Repositorios;

namespace TotalControl.DAL.Interface
{
    public interface ICategoriaRepositorio : IRepositorioGenerico<Categoria>
    {
        new IQueryable<Categoria> PegarTodos();
        
        new Task<Categoria> PegarPeloId(int Id);

        IQueryable<Categoria> FiltrarCategoria(string nomeCatergoria);


        //new Task<Categoria> PegarPeloId(string Id);
        //new Task Inserir(Categoria entity);
        //new Task Inserir(List<Categoria> entity);
        //new Task Atualizar(Categoria entity);
        //new Task Excluir(string id);
        //new Task Excluir(int id);
    }
}
