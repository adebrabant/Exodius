using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;
using Mock.SwagLabs.Products.Enums;
using Mock.SwagLabs.Utilities;

namespace Mock.SwagLabs.Products.Components;

public class ProductSortComponent(IDriver driver, IEntity owner, IEventBus eventBus) 
    : EntityComponent(driver, owner, eventBus), IProductSortComponent
{
    private SelectElement ProductSelectElement => Driver.FindElement<ByTestData, SelectElement>("product-sort-container");

    public async Task<IProductSortComponent> SetFilter(ProductFilter filter)
    {
        await ProductSelectElement.SelectValueAsync(filter.GetHtmlValue());

        return this;
    }
}
