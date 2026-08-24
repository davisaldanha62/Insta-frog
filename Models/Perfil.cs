namespace PortfolioApi.Models;

public class Perfil
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string UrlFotoPerfil { get; set; } = string.Empty;
}