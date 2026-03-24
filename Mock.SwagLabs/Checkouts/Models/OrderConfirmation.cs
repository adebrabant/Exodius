namespace Mock.SwagLabs.Checkouts.Models;

public record OrderConfirmation
{
    public string Header { get; init; } = "";
    public string Text { get; init; } = "";
}