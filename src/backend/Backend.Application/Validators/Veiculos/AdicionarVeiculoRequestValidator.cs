using Backend.Application.Configurations.Bases;
using Backend.Domain.Veiculos.ApplicationServices.Requests;
using FluentValidation;

namespace Backend.Application.Validators.Veiculos;

public class AdicionarVeiculoRequestValidator : BaseAbstractValidator<AdicionarVeiculoRequest>
{
    public AdicionarVeiculoRequestValidator()
    {
        RuleFor(x => x.Nome)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Nome é obrigatório");

        RuleFor(x => x.Valor)
            .GreaterThan(0).WithMessage("O campo Valor deve ser maior que zero");

        RuleFor(x => x.MarcaId)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Marca é obrigatório")
            .Must(ValidarGuid).WithMessage("O campo Marca é inválido");

        RuleFor(x => x.ModeloId)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Modelo é obrigatório")
            .Must(ValidarGuid).WithMessage("O campo Modelo é inválido");
    }
}