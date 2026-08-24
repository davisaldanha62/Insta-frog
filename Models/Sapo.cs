namespace PortfolioApi.Models;

public class Sapo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Habitat { get; set; } = string.Empty; // Antigo "Universo"
    public string Tipo { get; set; } = string.Empty;     // Antigo "ClasseOuPapel"
    public string UrlImagem { get; set; } = string.Empty;
    public bool Favorito { get; set; }
}