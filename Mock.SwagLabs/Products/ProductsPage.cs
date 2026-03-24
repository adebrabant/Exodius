using AD.Exodius.Entities.Pages;
using AD.Exodius.Entities.Pages.Attributes;
using AD.Exodius.Entities.Pages.Registries;
using AD.Exodius.Events;
using Mock.SwagLabs.Common.Components;
using Mock.SwagLabs.Products.Components;
using Mock.SwagLabs.Products.Models;

namespace Mock.SwagLabs.Products;

[PageEntityMeta(
    Route = "/inventory.html",
    Name = "Products",
    DomId = "inventory-sidebar-link",
    Registry = typeof(ProductsPageRegistry)
)]
public class ProductsPage(IDriver driver, IEventBus eventBus) : PageEntity(driver, eventBus)
{
    public async Task AddItemToCartAsync(Product product)
    {
        var inventory = GetComponent<InventoryComponent>();
        await inventory.AddItemToCartAsync(product);
    }
}

public class ProductsPageRegistry : IPageEntityRegistry
{
    public void RegisterComponents<TPage>(TPage page) where TPage : IPageEntity
    {
        page.AddComponent<LogoWaitComponent>();
        page.AddComponent<TitleWaitComponent>();
        page.AddComponent<ProductSortComponent>();
        page.AddComponent<InventoryComponent>();
        page.AddComponent<NavigationActionComponent>();
    }
}
