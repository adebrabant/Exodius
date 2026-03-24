using AD.Exodius.Entities.Pages;
using AD.Exodius.Entities.Pages.Attributes;
using AD.Exodius.Entities.Pages.Registries;
using AD.Exodius.Events;
using AD.Exodius.Helpers;
using Mock.SwagLabs.Checkout.Components;
using Mock.SwagLabs.Checkouts.Components;
using Mock.SwagLabs.Checkouts.Models;
using Mock.SwagLabs.Common.Components;

namespace Mock.SwagLabs.Checkouts;

[PageEntityMeta(
    Route = "/checkout-step-one.html",
    Registry = typeof(CheckoutPageRegistry),
    Name = "CheckoutPage",
    DomId = "some"
)]
public class CheckoutPage(IDriver driver, IEventBus eventBus) : PageEntity(driver, eventBus)
{
    public async Task<OrderConfirmation> FinishOrderAsync(CheckoutForm checkoutForm)
    {
        await GetComponent<CheckoutFormComponent>()
            .Then(component => component.FillFormAsync(checkoutForm));

        await GetComponent<CheckoutActionComponent>()
            .Then(component => component.ClickContinueButtonAsync());

        await GetComponent<CheckoutOverviewActionComponent>()
            .Then(component => component.ClickFinishButtonAsync());

        return await GetComponent<CheckoutCompleteComponent>()
            .Then(x => x.GetOrderConfirmationAsync());
    }
}

public class CheckoutPageRegistry : IPageEntityRegistry
{
    public void RegisterComponents<TPage>(TPage page) where TPage : IPageEntity
    {
        page.AddComponent<LogoWaitComponent>();
        page.AddComponent<TitleWaitComponent>();
        page.AddComponent<CheckoutFormComponent>();
        page.AddComponent<CheckoutSummaryComponent>();
        page.AddComponent<CheckoutActionComponent>();
        page.AddComponent<CheckoutOverviewActionComponent>();
        page.AddComponent<CheckoutCompleteComponent>();
    }
}