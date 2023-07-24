namespace Backend.Api.Sections;

public class Identity
{
    public string Secret { get; set; }
    public int ExpiracaoHoras { get; set; }
    public string Emissor { get; set; }
    public string ValidoEm { get; set; }
}