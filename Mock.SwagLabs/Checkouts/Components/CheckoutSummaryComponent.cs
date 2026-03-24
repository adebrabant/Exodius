using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;
using Mock.SwagLabs.Checkouts.Models;

namespace Mock.SwagLabs.Checkouts.Components;

public class CheckoutSummaryComponent(
    IDriver driver,
    IEntity owner,
    IEventBus eventBus) : EntityComponent(driver, owner, eventBus)
{
    private LabelElement PaymentInfoLabel =>
        Driver.FindElement<ByTestData, LabelElement>("payment-info-value");

    private LabelElement ShippingInfoLabel =>
        Driver.FindElement<ByTestData, LabelElement>("Free Pony Express Delivery!");

    private LabelElement PriceTotalCurrency =>
        Driver.FindElement<ByTestData, LabelElement>("total-label");

    public async Task<CheckoutSummary> GetSummaryAsync()
    {
        return new CheckoutSummary()
        {
            PaymentInformation = await PaymentInfoLabel.GetTextAsync(),
            ShippingInformation = await ShippingInfoLabel.GetTextAsync(),
            PriceTotal = await PriceTotalCurrency.GetNumericTextAsync(),
        };

    }
}
