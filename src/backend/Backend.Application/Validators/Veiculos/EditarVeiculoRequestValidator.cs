using Backend.Application.Configurations.Bases;
using Backend.Domain.Veiculos.ApplicationServices.Requests;
using FluentValidation;

namespace Backend.Application.Validators.Veiculos;

public class EditarVeiculoRequestValidator : BaseAbstractValidator<EditarVeiculoRequest>
{
    public EditarVeiculoRequestValidator()
    {
        RuleFor(x => x.Id)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Marca é obrigatório")
            .Must(ValidarGuid).WithMessage("O campo Marca é inválido");

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

        RuleFor(x => x.NomeDaImagem)
            .Must(ValidarStringNulaEVazia).WithMessage("O campo Nome da imagem é obrigatório");
    }
}