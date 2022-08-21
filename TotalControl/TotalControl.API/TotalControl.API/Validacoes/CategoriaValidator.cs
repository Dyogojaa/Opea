using FluentValidation;
using TotalControl.BLL.Models;

namespace TotalControl.API.Validacoes
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            //Criação das Regras  de Validação utilizando Fluent Validation
            RuleFor(c => c.Nome)
                .NotNull().WithMessage("Preencha o nome")
                .NotEmpty().WithMessage("Preencha o nome")
                .MinimumLength(6).WithMessage("Use 6 ou mais caracteres")
                .MaximumLength(50).WithMessage("Use 50 ou menos caractersa");

            RuleFor(c => c.Icone)
                .NotNull().WithMessage("Preencha o Icone")
                .NotEmpty().WithMessage("Preencha o Icone")
                .MinimumLength(1).WithMessage("Use 1 ou mais caracteres")
                .MaximumLength(15).WithMessage("Use 15 ou menos caractersa");

            RuleFor(c => c.TipoId)
                .NotNull().WithMessage("Escolha o Tipo")
                .NotEmpty().WithMessage("Escolha o Tipo");
                
        }
    }
}
