using FluentValidation;
using TotalControl.API.ViewModel;

namespace TotalControl.API.Validacoes
{
    public class RegistroViewModelValidator : AbstractValidator<RegistroViewModel>
    {
        public RegistroViewModelValidator()
        {
            //Criação das Regras  de Validação utilizando Fluent Validation
            RuleFor(c => c.NomeUsuario)
                .NotNull().WithMessage("Preencha o Nome de Usuário")
                .NotEmpty().WithMessage("Preencha Nome de Usuário")
                .NotEmpty().WithMessage("O Nome não pode conter espaços").Must(c => !string.IsNullOrWhiteSpace(c))
                .MinimumLength(6).WithMessage("Use 6 ou mais caracteres")
                .MaximumLength(50).WithMessage("Use 50 ou menos caracteres");

            RuleFor(c => c.CPF)
                .NotNull().WithMessage("Preencha o Número do CPF")
                .NotEmpty().WithMessage("Preencha O Número do CPF")
                .MinimumLength(11).WithMessage("Use 11 ou mais caracteres")
                .MaximumLength(20).WithMessage("Use 20 ou menos caracteres");


            RuleFor(c => c.Profissao)
                .NotNull().WithMessage("Preencha a Profissao")
                .NotEmpty().WithMessage("Preencha a Profissao")
                .MinimumLength(10).WithMessage("Use 10 ou mais caracteres")
                .MaximumLength(30).WithMessage("Use 30 ou menos caracteres");

            RuleFor(c => c.Foto)
                .NotNull().WithMessage("Escolha sua Foto")
                .NotEmpty().WithMessage("Escolha sua Foto");
                                

            RuleFor(c => c.Email)
                .NotNull().WithMessage("Preencha o Email")
                .NotEmpty().WithMessage("Preencha o Email")
                .MinimumLength(10).WithMessage("Use 10 ou mais caracteres")
                .MaximumLength(50).WithMessage("Use 50 ou menos caracteres")
                .EmailAddress().WithMessage("Email Inválido!");

            RuleFor(c => c.Senha)
                .NotNull().WithMessage("Preencha a Senha")
                .NotEmpty().WithMessage("Preencha a Senha")
                .MinimumLength(6).WithMessage("Use 6 ou mais caracteres")
                .MaximumLength(15).WithMessage("Use 15 ou menos caracteres");
                


        }
    }
}
