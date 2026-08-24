using PortfolioApi.Models;

namespace PortfolioApi.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Sapos.Any())
        {
            return; // O banco já tem dados
        }

        var sapos = new Sapo[]
        {
            new Sapo
            {
                Nome = "Sapo-vidro",
                Habitat = "Florestas Tropicais (perto de riachos)",
                Tipo = "Aquático / Transparente",
                UrlImagem = "/imagens/sapovidro.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Perereca-de-olhos-vermelhos",
                Habitat = "Florestas Tropicais (perto de água)",
                Tipo = "Arborícola / Fofinho",
                UrlImagem = "/imagens/perereca.jpeg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Axolote (Sapo d'água / anfíbio)",
                Habitat = "Lagos e Canais do México",
                Tipo = "Aquático / Super Fofo",
                UrlImagem = "/imagens/axolote.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Rã-leopardo",
                Habitat = "Pântanos e Margens de Rios",
                Tipo = "Aquático / Ágil",
                UrlImagem = "/imagens/raleopardo.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Perereca Verde Comum",
                Habitat = "Jardins e Lagoas da Europa",
                Tipo = "Aquático e Arborícola",
                UrlImagem = "/imagens/pererecaverde.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Sapo-flecha Azul",
                Habitat = "Áreas úmidas da Floresta Amazônica",
                Tipo = "Semi-aquático / Colorido",
                UrlImagem = "/imagens/sapoflecha.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Rã-touro Americana",
                Habitat = "Lagos e Lagoas de água doce",
                Tipo = "Aquático / Grande",
                UrlImagem = "/imagens/ratouro.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Perereca-de-White (Sapo Dumbo)",
                Habitat = "Florestas úmidas perto de água na Austrália",
                Tipo = "Arborícola / Muito Fofo",
                UrlImagem = "/imagens/pererecawhite.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Sapo-pintado Hula",
                Habitat = "Pântanos e Lagos rasos",
                Tipo = "Aquático",
                UrlImagem = "/imagens/sapohula.jpg",
                Favorito = false
            },
            new Sapo
            {
                Nome = "Rã-arqueira",
                Habitat = "Riachos de água doce",
                Tipo = "Aquático",
                UrlImagem = "/imagens/raarqueira.jpg",
                Favorito = false
            }
        };

        context.Sapos.AddRange(sapos);
        context.SaveChanges();
    }
}