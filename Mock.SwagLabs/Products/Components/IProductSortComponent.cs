using AD.Exodius.Components;
using Mock.SwagLabs.Products.Enums;

namespace Mock.SwagLabs.Products.Components;

public interface IProductSortComponent : IEntityComponent
{
    Task<IProductSortComponent> SetFilter(ProductFilter filter);
}