using Microsoft.AspNetCore.Identity;

namespace TotalControl.BLL.Models
{
    public class Usuario:IdentityUser<string>
    {
        
        public string CPF { get; set; } =string.Empty;  
        public string Profissao { get; set; } = string.Empty;
        public byte[]? Foto { get; set; } = null;
        public virtual ICollection<Cartao>? Cartaos { get; set; }
        public virtual ICollection<Ganho>? Ganhos { get; set; }
        public virtual ICollection<Despesa>? Despesas { get; set; }
    }
}