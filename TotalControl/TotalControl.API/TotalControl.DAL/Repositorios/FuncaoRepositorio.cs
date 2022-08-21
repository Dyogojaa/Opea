

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TotalControl.BLL.Models;
using TotalControl.DAL.Interface;

namespace TotalControl.DAL.Repositorios
{
    public class FuncaoRepositorio : RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {

        private readonly BDContexto _context;
        private readonly RoleManager<Funcao> _gerenciadorFuncao;

        public FuncaoRepositorio(BDContexto context, RoleManager<Funcao> gerenciadorFuncao) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _gerenciadorFuncao = gerenciadorFuncao ?? throw new ArgumentNullException(nameof(gerenciadorFuncao));
        }

        public async Task AdicionarFuncao(Funcao funcao)
        {
            try
            {
                await _gerenciadorFuncao.CreateAsync(funcao);   
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AtualizarFuncao(Funcao funcao)
        {
            try
            {
                Funcao f = await PegarPeloId(funcao.Id);
                f.Name = funcao.Name;
                f.NormalizedName = funcao.NormalizedName;
                f.Descricao = funcao.Descricao; 
                await _gerenciadorFuncao.UpdateAsync(f);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<Funcao> FiltrarFuncoes(string nome)
        {
            try
            {
                var entity = _context.Funcaos.Where(f => f.Name.Contains(nome));
                return entity;
                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
