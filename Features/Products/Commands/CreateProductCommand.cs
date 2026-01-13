using MediatR;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Features.Products.Commands;

// 1. The Command (Data needed to create)
public record PostProductCommand(ProductDTO ProductDto) : IRequest<Product>;

// 2. The Handler (Your database saving logic)
public class PostProductHandler : IRequestHandler<PostProductCommand, Product>
{
    private readonly AppDbContext _context;

    public PostProductHandler(AppDbContext context) => _context = context;

    public async Task<Product> Handle(PostProductCommand request, CancellationToken ct)
    {
        // Category check logic
        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == request.ProductDto.CategoryId, ct);
        if (!categoryExists)
        {
            throw new Exception("The specified CategoryId does not exist.");
        }

        var product = new Product
        {
            Name = request.ProductDto.Name,
            Price = request.ProductDto.Price,
            CategoryId = request.ProductDto.CategoryId
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(ct);

        return product;
    }
}