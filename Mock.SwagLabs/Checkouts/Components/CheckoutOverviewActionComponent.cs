using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;

namespace Mock.SwagLabs.Checkouts.Components;

public class CheckoutOverviewActionComponent(IDriver driver, IEntity owner, IEventBus eventBus) 
    : EntityComponent(driver, owner, eventBus)
{
    private ButtonElement FinishButton =>
        Driver.FindElement<ByTestData, ButtonElement>("finish");

    private ButtonElement CancelButton =>
        Driver.FindElement<ByTestData, ButtonElement>("cancel");

    public async Task ClickFinishButtonAsync() => await FinishButton.ClickAsync();

    public async Task ClickCancelButtonAsync() => await CancelButton.ClickAsync();
}
