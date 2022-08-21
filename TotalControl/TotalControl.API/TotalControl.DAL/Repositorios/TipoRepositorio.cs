using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalControl.BLL.Models;
using TotalControl.DAL.Interface;

namespace TotalControl.DAL.Repositorios
{
    public class TipoRepositorio : RepositorioGenerico<Tipo> , ITipoRepositorio
    {
        public TipoRepositorio(BDContexto context) : base(context)
        {
            
        }
    }
}
