using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public ApartmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Apartments.Include(a => a.Owner).ToListAsync());
    }

    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered(decimal maxPrice)
    {
        var apartments = await _context.Apartments
            .Where(a => a.pricepernight <= maxPrice)
            .Include(a => a.Owner)
            .ToListAsync();

        return Ok(apartments);
    }
}