using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalControl.BLL.Models
{
    public class Cartao 
    {
        public int CartaoId { get; set; }
        public string  Nome { get; set; } = string.Empty;
        public string Bandeira { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public decimal Limite { get; set; } 

        public string UsuarioId { get; set; } = string.Empty;

        public Usuario Usuario { get; set; }

        public virtual  ICollection<Despesa> Despesas { get; set; }





    }
}
