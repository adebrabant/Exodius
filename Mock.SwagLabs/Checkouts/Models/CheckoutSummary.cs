namespace Mock.SwagLabs.Checkouts.Models;

public record CheckoutSummary
{
    public string? PaymentInformation { get; init; }
    public string? ShippingInformation { get; init; }
    public string? PriceTotal { get; init; }
}