using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Features.Products.Queries;
using MyApp.Features.Products.Commands;

namespace MyApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        var result = await _mediator.Send(new GetProductsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(ProductDTO productDto)
    {
        var result = await _mediator.Send(new PostProductCommand(productDto));
        return CreatedAtAction(nameof(GetProducts), new { id = result.Id }, result);
    }
}