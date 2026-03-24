using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;

namespace Mock.SwagLabs.Checkout.Components;

public class CheckoutActionComponent(IDriver driver, IEntity owner, IEventBus eventBus)
    : EntityComponent(driver, owner, eventBus)
{
    private ButtonElement ContinueButton =>
    Driver.FindElement<ByTestData, ButtonElement>("continue");

    private ButtonElement CancelButton =>
        Driver.FindElement<ByTestData, ButtonElement>("cancel");

    public async Task ClickContinueButtonAsync() => await ContinueButton.ClickAsync();

    public async Task ClickCancelButtonAsync() => await CancelButton.ClickAsync();
}
