using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;

namespace Mock.SwagLabs.Carts.Components;

public class CartFooterComponent(IDriver driver, IEntity owner, IEventBus eventBus)
    : EntityComponent(driver, owner, eventBus)
{
    private ButtonElement CheckoutButton =>
        Driver.FindElement<ByTestData, ButtonElement>("checkout");

    private ButtonElement ContinueShoppingButton =>
        Driver.FindElement<ByTestData, ButtonElement>("continue-shopping");

    public async Task ClickCheckoutButtonAsync() => await CheckoutButton.ClickAsync();

    public async Task ClickContinueShoppingButtonAsync() => await ContinueShoppingButton.ClickAsync();
}