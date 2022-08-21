namespace TotalControl.BLL.Models
{
    public class Ganho
    { 
        public int GanhoId { get; set; }
        public string Descricao { get; set; } = string.Empty;   
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public decimal Valor { get; set; }
        public int Dia { get; set; }
        public int MesId { get; set; }
        public Mes? Mes { get; set; }
        public int Ano { get; set; }
        public string UsuarioId { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }

    }
}