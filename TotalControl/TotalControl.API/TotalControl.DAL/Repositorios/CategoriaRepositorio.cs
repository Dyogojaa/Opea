using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalControl.BLL.Models;
using TotalControl.DAL.Interface;

namespace TotalControl.DAL.Repositorios
{
    public class CategoriaRepositorio: RepositorioGenerico<Categoria> , ICategoriaRepositorio
    {
        private readonly BDContexto _context;

        public CategoriaRepositorio(BDContexto context):base(context)
        {
            _context = context;
        }

        public new IQueryable<Categoria> PegarTodos()
        {
            try
            {
                return _context.Categorias.Include(c => c.Tipo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public new async Task<Categoria> PegarPeloId(int id)
        {
            try
            {
                return await _context.Categorias.Include(c => c.Tipo).FirstOrDefaultAsync(c => c.CategoriaId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Categoria> FiltrarCategoria(string nomeCatergoria)
        {
            try
            {
                var categoria = _context.Categorias.Include(c => c.Tipo).
                    Where(c => c.Nome.Contains(nomeCatergoria));
                return categoria;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
