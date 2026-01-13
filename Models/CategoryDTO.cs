namespace MyApp.Models;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProductSimpleDTO> Products { get; set; } = new();
}

public class ProductSimpleDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}