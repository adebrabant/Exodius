using AD.Exodius.Helpers;
using AD.Exodius.Navigators.Strategies;
using Mock.SwagLabs.Products.Enums;
using Mock.SwagLabs.Products;
using Mock.SwagLabs.Products.Components;
using Mock.SwagLabs.Tests.Assertions;
using Mock.SwagLabs.Tests.Fixtures;
using NUnit.Framework;

namespace Mock.SwagLabs.Tests.Products;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ProductSortFilterTests : BypassLoginTestStartup
{
    [TestCase(ProductFilter.AZ, SortOrder.Ascending)]
    [TestCase(ProductFilter.ZA, SortOrder.Descending)]
    public async Task ProductSortFilter_ShouldSortItemNames_WhenFilterIsApplied(
        ProductFilter productFilter,
        SortOrder expectedSortOrder)
    {
        var productsPage = await Navigator
            .GoToAsync<ProductsPage, ByAction>();

        var productSortFilter = await productsPage
            .GetComponent<IProductSortComponent>()
            .Then(component => component.SetFilter(productFilter));

        var allItemNames = await productsPage
            .GetComponent<IInventoryComponent>()
            .Then(component => component.GetAllItemNamesInOrderAsync());

        allItemNames
            .Should()
            .BeInOrder(expectedSortOrder);
    }

    [TestCase(ProductFilter.LoHi, SortOrder.Ascending)]
    [TestCase(ProductFilter.HiLo, SortOrder.Descending)]
    public async Task ProductSortFilter_ShouldSortItemPrices_WhenFilterIsApplied(
        ProductFilter productFilter,
        SortOrder expectedSortOrder)
    {
        var productsPage = await Navigator
            .GoToAsync<ProductsPage, ByRoute>();

        var productSortFilter = await productsPage
            .GetComponent<IProductSortComponent>()
            .Then(component => component.SetFilter(productFilter));

        var allItemPrices = await productsPage
            .GetComponent<IInventoryComponent>()
            .Then(component => component.GetAllPricesInOrderAsync<decimal>());

        allItemPrices
            .Should()
            .BeInOrder(expectedSortOrder);
    }
}
