using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
{
    return await _context.Categories
        .Include(c => c.Products)
        .Select(c => new CategoryDTO
        {
            Id = c.Id,
            Name = c.Name,
            Products = c.Products.Select(p => new ProductSimpleDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList()
        })
        .ToListAsync();
}

    [HttpPost]
    public async Task<ActionResult<Category>> PostCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
    }
}