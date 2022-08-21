using FluentValidation;
using TotalControl.BLL.Models;

namespace TotalControl.API.Validacoes
{
    public class FuncoesValidator : AbstractValidator<Funcao>
    {
        public FuncoesValidator()
        {
            //Criação das Regras  de Validação utilizando Fluent Validation
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Preencha a Funçao")
                .NotEmpty().WithMessage("Preencha a Função")
                .MinimumLength(6).WithMessage("Use 6 ou mais caracteres")
                .MaximumLength(50).WithMessage("Use 50 ou menos caracteres");

            RuleFor(c => c.Descricao)
                .NotNull().WithMessage("Preencha a Descrição")
                .NotEmpty().WithMessage("Preencha a Descrição")
                .MinimumLength(6).WithMessage("Use 1 ou mais caracteres")
                .MaximumLength(50).WithMessage("Use 15 ou menos caracteres");            

        }
    }
}
