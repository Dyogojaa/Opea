using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalControl.DAL.Repositorios
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        IQueryable<TEntity> PegarTodos();
        Task<TEntity> PegarPeloId(int Id);
        Task<TEntity> PegarPeloId(string Id);
        Task Inserir(TEntity entity);
        Task Inserir(List<TEntity> entity);
        Task Atualizar(TEntity entity);
        Task Excluir(string id);
        Task Excluir(int id);

        Task Excluir(TEntity entity);


    }
}
