using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=personagens.db"));

builder.Services.AddControllers();

var app = builder.Build();

// Aplica a migration, cria o banco e popula os sapos na inicialização
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

// Permite ler arquivos estáticos da pasta wwwroot (como o index.html e as imagens)
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();