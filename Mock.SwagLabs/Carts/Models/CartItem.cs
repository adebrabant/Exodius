namespace Mock.SwagLabs.Carts.Models;

public record CartItem
{
    public string Name { get; init; } = "";
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}
