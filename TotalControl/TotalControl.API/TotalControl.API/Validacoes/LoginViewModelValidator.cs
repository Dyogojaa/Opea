using FluentValidation;
using TotalControl.API.ViewModel;

namespace TotalControl.API.Validacoes
{
    public class LoginViewModelValidator:AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(c => c.Email)
               .NotNull().WithMessage("Preencha o Email")
               .NotEmpty().WithMessage("Preencha o Email")
               .MinimumLength(10).WithMessage("Use 10 ou mais caracteres")
               .MaximumLength(50).WithMessage("Use 50 ou menos caracteres");

            RuleFor(c => c.Senha)
                .NotNull().WithMessage("Preencha a Senha")
                .NotEmpty().WithMessage("Preencha a Senha")
                .MinimumLength(6).WithMessage("Use 1 ou mais caracteres")
                .MaximumLength(50).WithMessage("Use 15 ou menos caracteres");
        }
    }
}
