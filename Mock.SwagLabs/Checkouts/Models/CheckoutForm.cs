namespace Mock.SwagLabs.Checkouts.Models;

public record CheckoutForm
{
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";
    public string PostalCode { get; init; } = "";
}