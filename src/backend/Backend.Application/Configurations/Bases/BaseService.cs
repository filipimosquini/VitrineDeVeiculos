namespace Backend.Application.Configurations.Bases;

public abstract class BaseService
{
    protected BaseService() => _Errors = new List<string>();

    private readonly List<string> _Errors;

    public IReadOnlyCollection<string> Errors => _Errors;

    public bool IsValid => _Errors.Any() == false;

    public void AddError(string error)
    {
        _Errors.Add(error);
    }

    public void AddErrors(List<string> errors)
    {
        _Errors.AddRange(errors);
    }

    public void AddErrors(IReadOnlyCollection<string> errors)
    {
        _Errors.AddRange(errors);
    }
}