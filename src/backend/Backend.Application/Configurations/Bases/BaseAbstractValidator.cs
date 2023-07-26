using FluentValidation;

namespace Backend.Application.Configurations.Bases;

public abstract class BaseAbstractValidator<T> : AbstractValidator<T>
{
    public bool ValidarStringNulaEVazia(string campo)
    {
        if (string.IsNullOrWhiteSpace(campo))
        {
            return false;
        }

        return true;
    }

    public bool ValidarGuid(string campo)
    {
        return Guid.TryParse(campo, out _);
    }
}