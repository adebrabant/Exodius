using AD.Exodius.Entities.Pages;
using AD.Exodius.Entities.Pages.Attributes;
using AD.Exodius.Entities.Pages.Registries;
using AD.Exodius.Events;
using Mock.SwagLabs.Carts.Components;
using Mock.SwagLabs.Common.Components;

namespace Mock.SwagLabs.Carts;

[PageEntityMeta(
    Route = "/cart.html",
    Registry = typeof(CartPageRegistry),
    Name = "Cart",
    DomId = "shopping-cart-link"
)]
public class CartPage : PageEntity
{
    public CartPage(IDriver driver, IEventBus eventBus) 
        : base(driver, eventBus)
    {

    }

    public async Task ProcessAsync()
    {
        var cartFooterComponent = GetComponent<CartFooterComponent>();
        await cartFooterComponent.ClickCheckoutButtonAsync();
    }
}

public class CartPageRegistry : IPageEntityRegistry
{
    public void RegisterComponents<TPage>(TPage page) where TPage : IPageEntity
    {
        page.AddComponent<LogoWaitComponent>();
        page.AddComponent<TitleWaitComponent>();
        page.AddComponent<CartFooterComponent>();
        page.AddComponent<CartListComponent>();
    }
}