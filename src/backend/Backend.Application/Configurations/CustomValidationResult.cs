using Backend.Domain.Bases.ApplicationServices;
using FluentValidation.Results;

namespace Backend.Application.Configurations;

public class CustomValidationResult : ValidationResult, ICustomValidationResult
{
    public object? Data { get; set; }

    public bool HasErrors()
    => Errors.Any();
}