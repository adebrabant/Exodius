using AD.Exodius.Components;

namespace Mock.SwagLabs.Products.Components;

public interface IInventoryComponent : IEntityComponent
{
    Task<List<string>> GetAllItemNamesInOrderAsync();

    Task<List<TPrimitive>> GetAllPricesInOrderAsync<TPrimitive>();
}