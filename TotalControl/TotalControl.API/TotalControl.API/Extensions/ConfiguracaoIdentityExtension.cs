using Microsoft.AspNetCore.Identity;

namespace TotalControl.API.Extensions
{
    public  static class ConfiguracaoIdentityExtension
    {
        public static void ConfigurarSenhaUsuario(this IServiceCollection services)
        {
           services.Configure<IdentityOptions>(options =>
           {
               options.Password.RequireDigit = false;   
               options.Password.RequireLowercase = false;
               options.Password.RequiredLength = 6;
               options.Password.RequireNonAlphanumeric = false; 
               options.Password.RequireUppercase = false;
               options.Password.RequiredUniqueChars = 0;


           });
        }
    }
}
