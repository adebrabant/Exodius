using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;
using Mock.SwagLabs.Checkouts.Models;

namespace Mock.SwagLabs.Checkouts.Components;

public class CheckoutCompleteComponent(IDriver driver, IEntity owner, IEventBus eventBus)
    : EntityComponent(driver, owner, eventBus)
{
    private LabelElement CompleteHeaderLabel =>
        Driver.FindElement<ByTestData, LabelElement>("complete-header");

    private LabelElement CompleteTextLabel =>
        Driver.FindElement<ByTestData, LabelElement>("complete-text");

    private ButtonElement BackHomeButton =>
        Driver.FindElement<ByTestData, ButtonElement>("back-to-products");

    public async Task<OrderConfirmation> GetOrderConfirmationAsync()
    {
        return new OrderConfirmation
        { 
            Header = await CompleteHeaderLabel.GetTextAsync(),
            Text = await CompleteTextLabel.GetTextAsync()
        };
    }

    public async Task ClickBackToHomeAsync()
    {
        await BackHomeButton.ClickAsync();
    }

}