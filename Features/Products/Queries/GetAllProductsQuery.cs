using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Features.Products.Queries;

// 1. The Request definition
public record GetProductsQuery() : IRequest<IEnumerable<ProductDTO>>;

// 2. The Handler (The logic from your current GetProducts method)
public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
{
    private readonly AppDbContext _context;

    public GetProductsHandler(AppDbContext context) => _context = context;

    public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken ct)
    {
        return await _context.Products
            .Include(p => p.Category)
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.Name : "No Category"
            })
            .ToListAsync(ct);
    }
}