namespace Backend.Domain.Usuarios.Requests;

public class AdicionarUsuarioRequest
{
    public string Email { get; set; }
    public string Senha { get; set; }
    public string ConfirmarSenha { get; set; }
}