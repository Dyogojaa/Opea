using System.Text.Json.Serialization;

namespace TotalControl.BLL.Models
{
    public class Categoria 
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty; 
        public string  Icone { get; set; } = string.Empty;

        public int TipoId { get; set; }
        
        
        public Tipo? Tipo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Despesa>? Despesas { get; set; }
        [JsonIgnore]
        public virtual ICollection<Ganho>? Ganhos { get; set; }  

    }
}