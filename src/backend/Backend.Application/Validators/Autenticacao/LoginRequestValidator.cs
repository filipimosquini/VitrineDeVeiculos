using Backend.Domain.Autenticacao.Requests;
using FluentValidation;

namespace Backend.Application.Validators.Autenticacao;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().NotNull().WithMessage("O campo e-mail é obrigatório")
            .EmailAddress().WithMessage("O campo e-mail está em formato inválido");

        RuleFor(x => x.Senha)
            .NotEmpty().NotNull().WithMessage("O campo senha é obrigatório")
            .Length(6, 15).WithMessage("A senha deve conter entre 6 a 15 caracteres");
    }
}