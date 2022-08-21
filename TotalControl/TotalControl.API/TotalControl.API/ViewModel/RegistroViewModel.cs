namespace TotalControl.API.ViewModel
{
    public class RegistroViewModel
    {
        public string NomeUsuario { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;

        public Byte[]? Foto { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;


    }
}
