using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerfilController : ControllerBase
{
    private readonly AppDbContext _context;

    public PerfilController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Perfil>> GetPerfil()
    {
        var perfil = await _context.Set<Perfil>().FirstOrDefaultAsync();
        if (perfil == null) return NotFound();
        return perfil;
    }

    [HttpPost]
    public async Task<ActionResult<Perfil>> SalvarPerfil([FromForm] string nome, [FromForm] string bio, IFormFile? foto)
    {
        try
        {
            var perfil = await _context.Set<Perfil>().FirstOrDefaultAsync();

            string caminhoFoto = perfil?.UrlFotoPerfil ?? "/imagens/default-user.png";

            if (foto != null && foto.Length > 0)
            {
                var pastaImagens = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");
                if (!Directory.Exists(pastaImagens)) Directory.CreateDirectory(pastaImagens);

                var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                var caminhoCompleto = Path.Combine(pastaImagens, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await foto.CopyToAsync(stream);
                }
                caminhoFoto = "/imagens/" + nomeArquivo;
            }

            if (perfil == null)
            {
                perfil = new Perfil
                {
                    Nome = nome ?? "Usuário",
                    Bio = bio ?? "",
                    UrlFotoPerfil = caminhoFoto
                };
                _context.Set<Perfil>().Add(perfil);
            }
            else
            {
                perfil.Nome = nome ?? perfil.Nome;
                perfil.Bio = bio ?? perfil.Bio;
                perfil.UrlFotoPerfil = caminhoFoto;
            }

            await _context.SaveChangesAsync();
            return Ok(perfil);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}