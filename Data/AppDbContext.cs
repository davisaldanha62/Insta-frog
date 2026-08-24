using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Sapo> Sapos => Set<Sapo>();
    public DbSet<Perfil> Perfils => Set<Perfil>(); // <--- Adicione esta linha
}