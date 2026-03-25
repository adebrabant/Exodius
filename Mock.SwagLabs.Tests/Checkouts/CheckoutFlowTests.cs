using AD.Exodius.Helpers;
using AD.Exodius.Navigators.Strategies;
using Mock.SwagLabs.Carts;
using Mock.SwagLabs.Checkouts;
using Mock.SwagLabs.Checkouts.Models;
using Mock.SwagLabs.Products;
using Mock.SwagLabs.Products.Models;
using Mock.SwagLabs.Tests.Fixtures;
using NUnit.Framework;

namespace Mock.SwagLabs.Tests.Checkouts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CheckoutFlowTests : BypassLoginTestStartup
{
    [TestCaseSource(nameof(CheckoutTestData))]
    public async Task CheckoutFlow_ShouldCompleteOrder_WhenValidItemAndFormProvided(
        Product product,
        CheckoutForm checkoutForm)
    {
        var productsPage = await Navigator
            .GoToAsync<ProductsPage, ByRoute>()
            .Then(page => page.AddItemToCartAsync(product));

        var cartPage = await Navigator
            .GoToAsync<CartPage, ByRoute>()
            .Then(page => page.ProcessAsync());

        var orderConfirmation = await Navigator
            .GoToAsync<CheckoutPage, ByNoOp>()
            .Then(page => page.FinishOrderAsync(checkoutForm));

        orderConfirmation.Header.Should().Be("Thank you for your order!");
        orderConfirmation.Text.Should().Contain("Your order has been dispatched");
    }

    private static IEnumerable<TestCaseData> CheckoutTestData()
    {
        yield return new TestCaseData(
            new Product("Sauce Labs Backpack"),
            new CheckoutForm
            {
                FirstName = "Jon",
                LastName = "Smith",
                PostalCode = "12345"
            });
    }
}
