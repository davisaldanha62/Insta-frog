using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaposController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    // GET: api/sapos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sapo>>> GetSapos()
    {
        return await _context.Sapos.ToListAsync();
    }

    // POST: api/sapos
    [HttpPost]
    public async Task<ActionResult<Sapo>> PostSapo(Sapo sapo)
    {
        _context.Sapos.Add(sapo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSapos), new { id = sapo.Id }, sapo);
    }
}