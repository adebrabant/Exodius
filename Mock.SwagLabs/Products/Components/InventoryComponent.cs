using AD.Exodius.Components;
using AD.Exodius.Entities;
using AD.Exodius.Events;
using AD.Exodius.Locators;
using Mock.SwagLabs.Products.Models;
using Mock.SwagLabs.Utilities;
using System.Text.RegularExpressions;

namespace Mock.SwagLabs.Products.Components;

public class InventoryComponent(IDriver driver, IEntity owner, IEventBus eventBus) 
    : EntityComponent(driver, owner, eventBus), IInventoryComponent
{
    private Task<List<LabelElement>> ItemNames => Driver.FindAllElements<ByTestData, LabelElement>("inventory-item-name");

    private Task<List<LabelElement>> ItemPrices => Driver.FindAllElements<ByTestData, LabelElement>("inventory-item-price");

    public async Task AddItemToCartAsync(Product product)
    {
        var normalizedName = NormalizeItemName(product.Name);
        var buttonTestId = $"add-to-cart-{normalizedName}";

        var button = Driver.FindElement<ByTestData, ButtonElement>(buttonTestId);
        await button.ClickAsync();
    }

    public async Task RemoveItemFromCartAsync(Product product)
    {
        var normalizedName = NormalizeItemName(product.Name);
        var buttonTestId = $"remove-{normalizedName}";

        var button = Driver.FindElement<ByTestData, ButtonElement>(buttonTestId);
        await button.ClickAsync();
    }

    public async Task<List<string>> GetAllItemNamesInOrderAsync()
    {
        return await GetAllLabelElementsInOrderAsync<string>(ItemNames);
    }

    public async Task<List<TPrimitive>> GetAllPricesInOrderAsync<TPrimitive>()
    {
        return await GetAllLabelElementsInOrderAsync<TPrimitive>(ItemPrices);
    }

    private async Task<List<TPrimitive>> GetAllLabelElementsInOrderAsync<TPrimitive>(Task<List<LabelElement>> elements)
    {
        var elementsInOrder = new List<TPrimitive>();
        foreach (var element in await elements)
        {
            var elementText = await element.GetTextAsync();
            elementsInOrder.Add(elementText.ConvertToType<TPrimitive>());
        }

        return elementsInOrder;
    }

    private string NormalizeItemName(string itemName)
    {
        return Regex.Replace(itemName.ToLower(), @"[\s_]+", "-");
    }
}
