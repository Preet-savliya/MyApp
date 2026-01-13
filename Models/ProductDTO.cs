public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; } // Add this line!
    public string CategoryName { get; set; } = string.Empty;
}